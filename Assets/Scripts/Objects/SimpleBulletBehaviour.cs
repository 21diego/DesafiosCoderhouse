using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] int damage = 10;
    [SerializeField] float liveTime = 3f;

    public int Damage { get => damage; set => damage = value; }


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyDelay", liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
    }

    private void DestroyDelay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Chocando");
            Destroy(gameObject);
        }
    }
}
