using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected EnemyData enemyData;
    [SerializeField] protected Transform playerTransform;
    private bool canAttack = true;

    protected bool CanAttack { get => canAttack; set => canAttack = value; }

    private void Awake() {
        FindObjectOfType<HUDManager>().OnGameOver += EndGame;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void Movement()
    {
        LookAtPlayer();
    }

    protected virtual void Attack() {}
    protected virtual void  Attack(PlayerMechanics player)
    {
        StartCoroutine(AttackWithDelay(player));
        
    }
    
    IEnumerator AttackWithDelay(PlayerMechanics player){
        //Espera 1 segundo a que termine la animacion de ataque
        yield return new WaitForSeconds(1);
        player.Damage(enemyData.Damage);
        yield return null;
    }
    protected void LookAtPlayer()
    {
        // Determino la nueva rotacion
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }

    protected void delayAttack()
    {
        Debug.Log("delayAttack");
        CanAttack = true;
    }

    void EndGame () {
        Destroy(gameObject);
    }
}
