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
        this.PlayerSpeed = 1f;
        this.Direccion = new Vector3(0f,0f,0f);
        transform.localScale = transform.localScale * this.PlayerScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += this.Direccion * PlayerSpeed * Time.deltaTime;
    }

}
