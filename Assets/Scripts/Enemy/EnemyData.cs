using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Data/Create new Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Datos principales")]
    [Tooltip("Daño principal del Enemigo")]
    [SerializeField] int damage;


    [Tooltip("Salud del Enemigo")]
    [SerializeField] int health;

    [Header("Datos de comportamiento")]
    [Tooltip("Velocidad de movimiento del Enemigo")]
    [SerializeField][Range(1f, 5f)] float speedMovement = 2f;
    

    public int Damage { get => damage; set => damage = value; }
    public int Health { get => health; set => health = value; }
    public float SpeedMovement { get => speedMovement; set => speedMovement = value; }
}
