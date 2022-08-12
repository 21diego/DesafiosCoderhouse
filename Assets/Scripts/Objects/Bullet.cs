using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;
    public int damage;
    private Vector3 rotation;
    public float liveTime = 3f;

    // Utilizo esta fase como constructor
    void Awake()
    {
        this.direction = new Vector3(0f, 1f, 0f);
        this.damage = 1;
        this.rotation = new Vector3(0f, 0f, 90f);
    }
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
        //transform.position += this.direction * this.speed * Time.deltaTime;
        transform.Translate(this.direction * this.speed * Time.deltaTime);
    }

    private void DestroyDelay()
    {
        Debug.Log("DESTROY DELAY");
        Destroy(gameObject);
    }
}
