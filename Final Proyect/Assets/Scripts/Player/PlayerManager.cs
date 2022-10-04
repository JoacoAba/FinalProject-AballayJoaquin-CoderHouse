using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int life = 100; 
    public int HP {get {return life;}}
    public void Healing(int val)
    {
        if(life + val > 100)
        {
            life = 100;
        }
        else
        {
            life += val;
        }
    }

    // Update is called once per frame
    public void Damage(int val)
    {
        if(life - val < 0)
        {
            life = 0;
        }
        else
        {
            life -= val;
        }
    }
}
