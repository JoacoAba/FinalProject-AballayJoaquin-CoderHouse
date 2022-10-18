using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesGen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] Plane;
    void Start()
    {
        InvokeRepeating("Planes", 0f, 8f);
    }

    private void Planes()
    {
        Instantiate(Plane[Random.Range(0,2)], transform.position, transform.rotation);
    }
}
