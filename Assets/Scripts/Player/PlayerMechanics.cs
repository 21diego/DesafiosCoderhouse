using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData.ActualHealth = playerData.MaxHealth;
        GameManager.instance.HealthPalyer = playerData.ActualHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //this.Heal(this.heal);

        //this.Damage(this.damage);
    }

    // Este metodo se encarga de mover a nuestro jugador
    private void Movement()
    {
        transform.position += playerData.Direction * playerData.Speed * Time.deltaTime;
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
        if (playerData.ActualHealth <= 0)
        {
            Debug.Log("Dejalo, el jugador ya esta muerto :(");
        }
        else
        {
            playerData.ActualHealth -= damageToReceive;
        }

        HUDManager.SetHPBar(playerData.ActualHealth);
    }

}
