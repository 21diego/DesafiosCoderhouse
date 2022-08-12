using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    [SerializeField] Transform[] respawnPoints;
    [SerializeField] float cooldown = 2f;
    private float timeInContact;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Contacto con " + other.gameObject.name);
        timeInContact = 0;

    }

    private void OnCollisionStay(Collision other)
    {
        
        timeInContact += Time.deltaTime;

        if(timeInContact > cooldown){
            timeInContact = 0f;
            var rndPosition  = Random.Range(0, 3);
            other.gameObject.transform.position = respawnPoints[rndPosition].position;
            other.gameObject.transform.rotation = respawnPoints[rndPosition].rotation;
        }
    }
}
