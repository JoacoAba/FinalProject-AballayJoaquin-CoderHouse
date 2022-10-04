using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Crear Bullet Data")]
public class Scriptables : ScriptableObject
{
    [Header("Velocidad de bala.")][Tooltip("La velocidad de movimiento es entre 1 y 3")][SerializeField][Range(1, 3)]public float speed = 2f;
    [Header("Tiempo de despawn de bala.")][Tooltip("El tiempo de despawn es entre 5 y 10")][SerializeField][Range(5, 10)] public float DesDelay = 8f;
}
