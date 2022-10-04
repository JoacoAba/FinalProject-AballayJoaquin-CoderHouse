using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesMov : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(3,8)]
    private float speed = 3f;
    void Start()
    {
        Invoke("Delete", 18f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
