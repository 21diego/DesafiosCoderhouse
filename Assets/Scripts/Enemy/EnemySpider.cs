using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("Player") && CanAttack){
            Attack(other.gameObject.GetComponent<PlayerMechanics>());
            CanAttack = false;
            Invoke("delayAttack", 2f);
            Debug.Log("Atacando a Player");
        }
    }

    void delayAttack()
    {
        CanAttack = true;
    }

    protected override void Attack(PlayerMechanics player)
    {
        player.Damage(Damage);
        HUDManager.SetHPBar(player.ActualHealth);
    }


}
