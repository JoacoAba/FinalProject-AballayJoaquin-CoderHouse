using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HABMov : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(1, 4)]
    float speed = 1.4f;
    [SerializeField]
    [Range(20, 30)]
    float DestroyDelay = 22f;
    void Start()
    {
        Invoke("Delete", DestroyDelay);
    }
    void Update()
    {
        Move();
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
