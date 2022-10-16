using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected PlayerScriptables PScriptable;
    public Animator PlayerAnimator;
    private float CameraAxisX = 0f;


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
            if(!IsAnimating("Forward")){PlayerAnimator.SetTrigger("Forward");}
            Move(Vector3.forward);
        }
        if(Input.GetKey(KeyCode.A))
        {
            if(!IsAnimating("Left")){PlayerAnimator.SetTrigger("Left");}
            Move(Vector3.left);
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(!IsAnimating("Right")){PlayerAnimator.SetTrigger("Right");}
            Move(Vector3.back);
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(!IsAnimating("Back")){PlayerAnimator.SetTrigger("Back");}
            Move(Vector3.right);
        }
        if(Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.A))
        {
            if(!IsAnimating("LeftBack")){PlayerAnimator.SetTrigger("LeftBack");}
        }
        if(Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.S))
        {
            if(!IsAnimating("RightBack")){PlayerAnimator.SetTrigger("RightBack");}
        }
        if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))
        {
            if(!IsAnimating("LeftForw")){PlayerAnimator.SetTrigger("LeftForw");}
        }
        if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S))
        {
            if(!IsAnimating("RightForw")){PlayerAnimator.SetTrigger("RightForw");}
        }
        if(Input.GetKeyUp(KeyCode.W)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.A)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.S)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.D)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.D)&&Input.GetKey(KeyCode.A)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.D)&&Input.GetKey(KeyCode.S)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.W)&&Input.GetKey(KeyCode.A)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
        if(Input.GetKeyUp(KeyCode.W)&&Input.GetKey(KeyCode.S)){if(!IsAnimating("Idle")){PlayerAnimator.SetTrigger("Idle");}}
    }

    bool IsAnimating(string animName)
    {
        return PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    void Move(Vector3 dir)
    {
        transform.Translate(dir * PScriptable.speed * Time.deltaTime);
    }

    void RotatePlayer()
    {
        CameraAxisX += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0, CameraAxisX * PScriptable.sensitivity, 0);
    }
    void Speed(float num)
    {
        PScriptable.speed = num;
    }
}
