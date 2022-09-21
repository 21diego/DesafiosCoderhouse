using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpider : Enemy
{
    [SerializeField] int poisonDamage;
    [SerializeField] int ticksPoison;
    private int ticks;
    private PlayerMechanics player;
    public event Action OnPoisoned;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(ticks == 0){
            CancelInvoke("delayPoisonDamage");
            ticks = ticksPoison;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && CanAttack)
        {
            player = other.gameObject.GetComponent<PlayerMechanics>();
            Attack();
            CanAttack = false;
            Invoke("delayAttack", 2f);
        }
    }


    protected override void Attack()
    {
        
        player.Damage(enemyData.Damage);
        InvokeRepeating("delayPoisonDamage", 1f, 1f);
    }

    void delayPoisonDamage()
    {
        player.Damage(poisonDamage);
        OnPoisoned?.Invoke();
        ticks--;
        
    }



}
