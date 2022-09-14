using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] private int pointsToUltimate = 3;

    public event Action OnDead;
    public UnityEvent OnUseUltimate;

    private bool canUseUltimate = false;
    private int pointsUltimate = 0;
    private float highDefault = 50f;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        playerData.ActualHealth = playerData.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUseUltimate)
        {
            GetComponentInChildren<Animator>(true).SetTrigger("ULTIMATE");
            OnUseUltimate?.Invoke();
        }
    }

    // Este metodo se encarga de sanar la vida del jugador
    // En caso de que su salud actual sea superior a la maxima no sanara
    // En caso de que sea menor que 0, el jugador estara muerto y se necesitara
    // la resucitacion de Sage :D
    public void Heal(int lifeToHeal)
    {
        if (!(playerData.ActualHealth < playerData.MaxHealth))
        {
            Debug.Log("El player supera la salud maxima: " + playerData.ActualHealth);
        }
        else if (playerData.ActualHealth <= 0)
        {
            Debug.Log("El jugador ha muerto :(");
        }
        else
        {
            playerData.ActualHealth += lifeToHeal;
        }
    }

    // Este mettodo se encarfa de quitar vida al jugador
    // En caso de que su vida sea igual o menor a 0, ya no se descontara vida al jugador
    public void Damage(int damageToReceive)
    {
        playerData.ActualHealth -= damageToReceive;
        HUDManager.SetHPBar(playerData.ActualHealth);
        //GetComponentInChildren<Animator>(true).SetTrigger("GETHIT");

        if (playerData.ActualHealth <= 0) OnDead?.Invoke();

    }

    public void RechargeUltimate()
    {
        pointsUltimate++;
        float newHigh = highDefault - (highDefault/pointsToUltimate) * pointsUltimate;
        float newPosy = (highDefault/pointsToUltimate);
        HUDManager.UpdateSkillUse(newHigh, newPosy, "Ultimate");
        if (pointsUltimate == pointsToUltimate){
            canUseUltimate = true;
            pointsUltimate = 0;
        }
    }


}
