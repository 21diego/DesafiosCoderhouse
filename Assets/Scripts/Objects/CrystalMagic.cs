using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMagic : MonoBehaviour
{
    [SerializeField] int points = 10;

    public int Points { get => points; set => points = value; }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player")){
            GameManager.instance.Score += points;
        }
    }
}
