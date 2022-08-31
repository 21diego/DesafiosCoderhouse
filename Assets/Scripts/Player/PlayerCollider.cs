using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] bool alreadyShrunk = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Estoy chocando con " + other.gameObject.name);
        if(other.gameObject.CompareTag( "Portal" ))
        {
            Debug.Log(other.gameObject.GetComponent<Portal>());
        }
        if(other.gameObject.CompareTag( "CrystalMagic" )){
            Debug.Log("Poder misterioso otorgado");
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag( "Bullet" )){
            int damage = other.gameObject.GetComponent<SimpleBulletBehaviour>().Damage;
            GameManager.instance.UpdateHealth( -damage );
            gameObject.GetComponent<PlayerMechanics>().Damage(damage);
        }

        if(other.gameObject.CompareTag("Fruit")){
            gameObject.GetComponent<PlayerInventory>().AddItem(other.gameObject.transform.GetChild(0).gameObject.tag);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            if (alreadyShrunk)
            {
                alreadyShrunk = false;
                transform.localScale *= other.gameObject.GetComponent<Portal>().getShrinkSize();
            }
            else
            {
                alreadyShrunk = true;
                transform.localScale /= other.gameObject.GetComponent<Portal>().getShrinkSize();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
