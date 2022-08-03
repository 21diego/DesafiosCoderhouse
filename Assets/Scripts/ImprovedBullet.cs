using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedBullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction;
    public int damage = 1;
    private Vector3 rotation;
    public float DestructionLapse = 3f;

    void Awake()
    {
        this.direction = new Vector3(-1f, 0f, 0f);
        this.rotation = new Vector3(0f, 0f, 90f);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyDelay", DestructionLapse);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space)){
            transform.localScale *=2;
        }
    }

    void Move()
    {
        //transform.position += this.direction * this.speed * Time.deltaTime;
        transform.Translate(this.direction * this.speed * Time.deltaTime);
    }

    void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
