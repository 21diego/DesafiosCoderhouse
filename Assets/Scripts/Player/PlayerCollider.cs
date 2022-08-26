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
        if(other.gameObject.CompareTag("Portal"))
        {
            Debug.Log(other.gameObject.GetComponent<Portal>());
        }
        if(other.gameObject.CompareTag("CrystalMagic" )){
            Debug.Log("Poder misterioso otorgado");
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Bullet" )){
            Debug.Log("Poder misterioso otorgado");
            GameManager.instance.HealthPalyer -= other.gameObject.GetComponent<SimpleBulletBehaviour>().Damage;
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
