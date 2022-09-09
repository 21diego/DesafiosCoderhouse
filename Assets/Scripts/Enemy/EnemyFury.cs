using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFury : Enemy
{

     private PlayerMechanics player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position);

        if (direction.magnitude < 6f && direction.magnitude > 0.5f)
        {
            LookAtPlayer();
            transform.position += direction.normalized * enemyData.SpeedMovement * Time.deltaTime;
            GetComponentInChildren<Animator>(true).SetBool("Run Forward", true);
        }
        else {
            GetComponentInChildren<Animator>(true).SetBool("Run Forward", false);
        }

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && CanAttack)
        {
            player = other.gameObject.GetComponent<PlayerMechanics>();
            Attack(player);
            CanAttack = false;
            Invoke("delayAttack", 2f);
            Debug.Log("Atacando a Player");
        }
    }

    
}
