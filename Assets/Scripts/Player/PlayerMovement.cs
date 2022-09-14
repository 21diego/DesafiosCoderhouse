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
    private Vector3 Direccion;

    private float cameraAxisX = 0f;
    Transform child;
    private bool canMove = true;

    private void Awake()
    {
        FindObjectOfType<HUDManager>().OnGameOver += StopMovement;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerScale = 1f;
        this.PlayerSpeed = 5f;
        this.Direccion = new Vector3(0f, 0f, 1f);
        transform.localScale = transform.localScale * this.PlayerScale;
        child = transform.Find("MaleCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            bool forward = Input.GetKey(KeyCode.W);
            bool back = Input.GetKey(KeyCode.S);
            bool left = Input.GetKey(KeyCode.A);
            bool right = Input.GetKey(KeyCode.D);

            // Solo adelante
            if (forward && !left && !right) Move(Vector3.forward, 0f);
            if (forward && left) Move(Vector3.forward + Vector3.left, 315f);
            if (forward && right) Move(Vector3.forward + Vector3.right, 45f);

            if (back && !left && !right) Move(Vector3.back, 180f);
            if (back && left) Move(Vector3.back + Vector3.left, 225f);
            if (back && right) Move(Vector3.back + Vector3.right, 135f);

            if (left && !forward && !back) Move(Vector3.left, 270f);
            if (right && !forward && !back) Move(Vector3.right, 90f);

            if (!forward && !back && !left && !right)
            {
                GetComponentInChildren<Animator>(true).SetBool("WALKING", false);
            }
        }
    }

    void Move(Vector3 direction, float look)
    {
        transform.Translate(direction * PlayerSpeed * Time.deltaTime);
        child.transform.rotation = Quaternion.Euler(0, look, 0);
        GetComponentInChildren<Animator>(true).SetBool("WALKING", true);
    }


    public void RotatePlayer()
    {
        this.cameraAxisX += Input.GetAxis("Mouse X");

        // Armo la nueva rotacion segun el mouse
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);

        // Aplico Lerp para que el movimiento sea gradual
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * Time.deltaTime);
    }

    void StopMovement()
    {
        canMove = false;
        GetComponentInChildren<Animator>(true).SetTrigger("DEAD");
    }

}
