using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HABGen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject HAB;
    [SerializeField]
    [Range(15, 20)]
    float RespawnRange = 15f;
    [SerializeField]
    float RespawnTimer = 0f;
    void Start()
    {
        InvokeRepeating("HABS", RespawnTimer, RespawnRange);
    }

    private void HABS()
    {
        Instantiate(HAB, transform.position, transform.rotation);
    }
}