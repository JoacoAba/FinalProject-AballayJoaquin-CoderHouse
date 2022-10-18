using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance {get => instance;}
    private PlayerManager playerManager;

    [SerializeField] private Slider hpBar;

    [SerializeField] private GameObject [] Crystals;

    [SerializeField] private GameObject LosePanel;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;

        Crystals[0].SetActive(false);
        Crystals[1].SetActive(false);
        Crystals[2].SetActive(false);

        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        if(playerManager.HP == 0)
        {
            Crystals[0].SetActive(false);
            Crystals[1].SetActive(false);
            Crystals[2].SetActive(false);
            
            LosePanel.SetActive(true);
        }
    }
    public static void setHPbar (int newVal)
    {
        instance.hpBar.value = newVal;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Fire Crystal")
        {
            Crystals[0].SetActive(true);
        }
        if(other.gameObject.name == "Earth Crystal")
        {
            Crystals[1].SetActive(true);
        }
        if(other.gameObject.name == "Dark Crystal")
        {
            Crystals[2].SetActive(true);
        }

    }
}
