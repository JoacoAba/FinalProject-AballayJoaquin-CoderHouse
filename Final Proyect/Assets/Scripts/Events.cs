using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public UnityEvent OnTriggerButton3D;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnTriggerButton3D?.Invoke();
            Debug.Log("Evento OnTriggerButton3D llamado por: "+other.name);
        }
    }
    
}
