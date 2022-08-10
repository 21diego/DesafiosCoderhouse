using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 5f)]
    float PlayerScale;

    [SerializeField]
    [Range(1f, 5f)]
    float PlayerSpeed;
    public Vector3 Direccion;

    private float cameraAxisX = 0f;

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
        RotatePlayer();

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

    public void RotatePlayer()
    {
        this.cameraAxisX += Input.GetAxis("Mouse X");

        // Armo la nueva rotacion segun el mouse
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);

        // Aplico Lerp para que el movimiento sea gradual
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * Time.deltaTime);
    }

}
