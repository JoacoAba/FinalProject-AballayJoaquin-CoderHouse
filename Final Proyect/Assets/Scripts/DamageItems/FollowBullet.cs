using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : BulletMov
{
    [SerializeField] Transform Player;
   
    public override void Move()
    {
        transform.LookAt(Player);
        base.Move();
    }
    
}    
