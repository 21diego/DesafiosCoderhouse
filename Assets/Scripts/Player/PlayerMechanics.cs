using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] int actualHealth;
    [SerializeField] int maxHealth;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    [SerializeField] int damage;
    [SerializeField] int heal;

    public int ActualHealth { get => actualHealth; set => actualHealth = value; }

    // Start is called before the first frame update
    void Start()
    {
        this.actualHealth = 100;
        this.maxHealth = 100;
        this.speed = 10f;
        this.direction = new Vector3(0f, 0f, 0f);
        this.damage = 0;
        this.heal = 0;

        GameManager.instance.HealthPalyer = actualHealth;
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
        transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // Este metodo se encarga de sanar la vida del jugador
    // En caso de que su salud actual sea superior a la maxima no sanara
    // En caso de que sea menor que 0, el jugador estara muerto y se necesitara
    // la resucitacion de Sage :D
    public void Heal(int lifeToHeal)
    {
        if (!(this.actualHealth < this.maxHealth))
        {
            Debug.Log("El player supera la salud maxima: " + this.actualHealth);
        }
        else if (this.actualHealth <= 0)
        {
            Debug.Log("El jugador ha muerto :(");
        }
        else
        {
            this.actualHealth += lifeToHeal;
        }
    }

    // Este mettodo se encarfa de quitar vida al jugador
    // En caso de que su vida sea igual o menor a 0, ya no se descontara vida al jugador
    public void Damage(int damageToReceive)
    {
        if (this.actualHealth <= 0)
        {
            Debug.Log("Dejalo, el jugador ya esta muerto :(");
        }
        else
        {
            this.actualHealth -= damageToReceive;
        }
    }

}
