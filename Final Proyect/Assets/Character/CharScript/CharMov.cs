using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharMov : MonoBehaviour
{   
    float CameraAxisX = 0f;

    public bool pause = false;
    
    public UnityEvent GameOver;

    public Animator PlayerAnimation;
    [SerializeField][Range(2, 5)] float speed = 3f;
    [SerializeField][Range(1, 2)] float delayNextJump = 1f;

    private float jumpForce = 5f;
    private bool inDelayJump = false;
    private bool canJump = true;

    public Rigidbody myRigidBody;

    
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddForce(Vector3.forward * 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause){
            RotatePlayer();
            if(Input.GetKey(KeyCode.W))
            {
                if(!IsAnimation("Forward")){PlayerAnimation.SetTrigger("Forward");}
                Move(Vector3.forward); 
            }
            if(Input.GetKey(KeyCode.A))
            {
                Move(Vector3.left);
                if(!IsAnimation("Left")){if(!IsAnimation("Jump")){PlayerAnimation.SetTrigger("Left");}}
            }
            if(Input.GetKey(KeyCode.S))
            {
                Move(Vector3.back);
                if(!IsAnimation("Back")){if(!IsAnimation("Jump")){PlayerAnimation.SetTrigger("Back");}}
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(!IsAnimation("Right")){if(!IsAnimation("Jump")){PlayerAnimation.SetTrigger("Right");}}
                Move(Vector3.right);
                
            }
            
            
        }    

        if(Input.GetKeyUp(KeyCode.W)){PlayerAnimation.SetTrigger("Idle");}
            if(Input.GetKeyUp(KeyCode.A)){PlayerAnimation.SetTrigger("Idle");}
            if(Input.GetKeyUp(KeyCode.S)){PlayerAnimation.SetTrigger("Idle");}
            if(Input.GetKeyUp(KeyCode.D)){PlayerAnimation.SetTrigger("Idle");}

    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("GameOver"))
        {
            pause = true;
        }
    }

    private void RotatePlayer()
    {
        CameraAxisX += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0f, CameraAxisX * 2f, 0f);
    }

    void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && !inDelayJump && canJump)
        {
            if(!IsAnimation("Jump"))
                {
                    PlayerAnimation.SetTrigger("Jump");
                }
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inDelayJump = true;
            canJump = false;
            Invoke("DelayNextJump", delayNextJump);
        }
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void DelayNextJump ()
    {
        inDelayJump = false;
        canJump = true;
    }
    bool IsAnimation(string animName)
    {
        return PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}
