using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerScale;
    public float PlayerSpeed;
    public Vector3 Direccion;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerScale = 1f;
        this.PlayerSpeed = 5f;
        this.Direccion = new Vector3(0f, 0f, 0f);
        transform.localScale = transform.localScale * this.PlayerScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    void Move(Vector3 direction)
    {
        transform.Translate(direction * PlayerSpeed * Time.deltaTime);
    }

}
