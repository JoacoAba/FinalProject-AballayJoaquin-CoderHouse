using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private PlayerManager playerManager;
    public UnityEvent OnCrystal;
    public UnityEvent OnCrystalWin;

    [SerializeField] GameObject HUD;

    [SerializeField] GameObject [] Crystals;
    List<GameObject> CrystalList;

    

    public List<GameObject> crystalList { get => CrystalList; set => CrystalList = value; }

    private void Start() 
    {
        playerManager = GetComponent<PlayerManager>();
        CrystalList = new List<GameObject>();
        HUDManager.setHPbar(playerManager.HP);
    }

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Crystal"))
        {
            OnCrystal?.Invoke();
            Invoke("DestroyHUD", 3f);
            crystalList.Add(gameObject);
            Destroy(other.gameObject);
            
            if(CrystalList.Count == 3)
            {
                OnCrystalWin.Invoke();
                Invoke("MainMenu", 2f);
            }
        }
        
        
        if(other.gameObject.CompareTag("GameOver"))
        {
            if(playerManager.HP != 0)
            {
                playerManager.Damage(other.gameObject.GetComponent<DamageItems>().Damage);
                HUDManager.setHPbar(playerManager.HP);
            }
            if(playerManager.HP == 0)
            {
                Invoke("MainMenu", 2f);
            }
        }
    }

    void DestroyHUD()
    {
        HUD.SetActive(false);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
