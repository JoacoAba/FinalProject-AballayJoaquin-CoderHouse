using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    [SerializeField][Range(0, 2)] float lerpValue;
    [SerializeField][Range(0, 2)] float CamSensibility = 0.5f;
    
    void Start()
    {
        target = GameObject.Find("Target").transform;
        
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * CamSensibility, Vector3.up) * offset;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
