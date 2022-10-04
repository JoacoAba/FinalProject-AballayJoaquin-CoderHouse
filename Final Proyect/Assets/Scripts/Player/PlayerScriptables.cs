using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Crear Player Data")]

public class PlayerScriptables : ScriptableObject
{
    [Header("Velocidad del jugador.")][Tooltip("Varía de 3 a 8")][SerializeField][Range(3, 8)] public float speed = 5f;
    [Header("Sensibilidad de cámara.")][Tooltip("Varía de 1 a 2")][SerializeField][Range(1,2)] public float sensitivity = 1f;
}
