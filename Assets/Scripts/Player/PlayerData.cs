using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Create new Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Datos principales")]
    [SerializeField] int actualHealth;
    [SerializeField] int maxHealth;

    [Header("Configuracion de movimiento")]
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    [Header("Configuracion de batalla")]
    [SerializeField] int damage;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public int ActualHealth { get => actualHealth; set => actualHealth = value; }
    public float Speed { get => speed; set => speed = value; }
    public Vector3 Direction { get => direction; set => direction = value; }
    public int Damage { get => damage; set => damage = value; }
}
