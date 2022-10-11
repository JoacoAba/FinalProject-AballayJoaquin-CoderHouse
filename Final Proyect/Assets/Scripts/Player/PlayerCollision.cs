using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
            }
        }
        
        if(other.gameObject.CompareTag("PowerUp"))
        {
            if(playerManager.HP < 100)
            {
                Destroy(other.gameObject);
                playerManager.Healing(other.gameObject.GetComponent<PowerUps>().HealPoints);
                Debug.Log(playerManager.HP);
                HUDManager.setHPbar(playerManager.HP);
            }   
            if(playerManager.HP == 100)
            {
                Destroy(other.gameObject);
            }
        }
        
        if(other.gameObject.CompareTag("DamageItem"))
        {
            if(playerManager.HP != 0)
            {
                Destroy(other.gameObject);
                playerManager.Damage(other.gameObject.GetComponent<DamageItems>().Damage);
                HUDManager.setHPbar(playerManager.HP);
            }
        }
    }

    void DestroyHUD()
    {
        HUD.SetActive(false);
    }
}
