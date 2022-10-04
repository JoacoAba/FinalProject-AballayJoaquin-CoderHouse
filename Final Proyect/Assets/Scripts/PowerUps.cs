using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField][Range(2, 10)] int healPoints = 2;
    public int HealPoints { get { return healPoints; } }
}