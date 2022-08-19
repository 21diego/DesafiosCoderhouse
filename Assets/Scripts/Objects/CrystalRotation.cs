using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRotation : MonoBehaviour
{
    [SerializeField] float speedRotation = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Aplico Lerp para que el movimiento sea gradual
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
    }
}
