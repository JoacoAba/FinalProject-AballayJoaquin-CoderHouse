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
    [SerializeField] Dictionary<string, GameObject> CrystalDirectory;

    

    public List<GameObject> crystalList { get => CrystalList; set => CrystalList = value; }
    public Dictionary<string, GameObject> crystalDirectory { get => CrystalDirectory; set => CrystalDirectory = value; }

    private void Start() 
    {
        playerManager = GetComponent<PlayerManager>();
        CrystalList = new List<GameObject>();
        CrystalDirectory = new Dictionary<string, GameObject>();
        HUDManager.setHPbar(playerManager.HP);
    }

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Crystal"))
        {
            OnCrystal?.Invoke();
            Invoke("DestroyHUD", 3f);
            Debug.Log("Evento OnCrystal llamado por: "+other.name);
            crystalList.Add(gameObject);
            crystalDirectory.Add(other.gameObject.name, other.gameObject);
            Debug.Log("Has recogido: "+ crystalDirectory[other.gameObject.name]);

            Destroy(other.gameObject);
            
            if(CrystalList.Count == 3)
            {
                OnCrystalWin.Invoke();
                Debug.Log("Evento OnCrystalWin llamado por: "+other.name);
                Debug.Log("Felicidades! Has conseguido los tres cristales!");
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
                Debug.Log("Su vida ya tiene " + playerManager.HP + " puntos.");
            }
        }
        
        if(other.gameObject.CompareTag("DamageItem"))
        {
            if(playerManager.HP != 0)
            {
                Destroy(other.gameObject);
                playerManager.Damage(other.gameObject.GetComponent<DamageItems>().Damage);
                
                Debug.Log(playerManager.HP);

                HUDManager.setHPbar(playerManager.HP);
            }
        }
    }

    void DestroyHUD()
    {
        HUD.SetActive(false);
    }
}
