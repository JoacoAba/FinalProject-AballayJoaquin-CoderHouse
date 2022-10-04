using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Bullet;
    [SerializeField] [Range(3, 6)] float SpawnDelay = 3f; 

    void Start()
    {
        InvokeRepeating("Spawn", 0f, SpawnDelay);
    }
    
    void Spawn()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}
