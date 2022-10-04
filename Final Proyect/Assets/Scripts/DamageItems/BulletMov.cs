using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    [SerializeField] protected Scriptables scriptables;
    void Start()
    {
        Invoke("DestroyBullet", scriptables.DesDelay);
    }

    void Update() 
    {
        Move(); 
    }

    public virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * scriptables.speed * Time.deltaTime);
    }
}
