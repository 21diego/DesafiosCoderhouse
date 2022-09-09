using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(1f, 5f)]
    private float speedMovement = 2f;

    enum EnemyMoveTypes { Chaser, Looker };
    [SerializeField] EnemyMoveTypes EnemyMoveType;

    //Guardamos una referencia al transform del player para movernos en su dirección.
    [SerializeField] protected Transform playerTransform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (EnemyMoveType)
        {
            case EnemyMoveTypes.Chaser:
                ChasePlayer();
                break;
            case EnemyMoveTypes.Looker:
                LookAtPlayer();
                break;
        }
    }

    private void ChasePlayer()
    {
        LookAtPlayer();
        // Con la resta obtenemos la direccion hacia el objetivo
        Vector3 direction = (playerTransform.position - transform.position);
       
        // Debe tener un limite de distancia
        if (direction.magnitude > 2f)
        {
           transform.position += direction.normalized * speedMovement * Time.deltaTime;
        }
    }
    
    private void LookAtPlayer()
    {
        // Determino la nueva rotacion
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

}
