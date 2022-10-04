using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance {get => instance;}
    

    [SerializeField] private Slider hpBar;

    [SerializeField] private GameObject [] Crystals;

    
    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() 
    {   
        Crystals[0].SetActive(false);
        Crystals[1].SetActive(false);
        Crystals[2].SetActive(false);
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
