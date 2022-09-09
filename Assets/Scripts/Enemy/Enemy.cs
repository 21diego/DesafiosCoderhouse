using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected EnemyData enemyData;
    [SerializeField] Transform playerTransform;
    private bool canAttack = true;

    protected bool CanAttack { get => canAttack; set => canAttack = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void Movement()
    {
        LookAtPlayer();
    }

    protected virtual void Attack() { }

    protected void LookAtPlayer()
    {
        // Determino la nueva rotacion
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }
}
