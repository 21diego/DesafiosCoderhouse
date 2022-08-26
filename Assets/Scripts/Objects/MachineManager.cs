using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManager: MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float rayDistance = 5f;
    [SerializeField] private GameObject bullet;
    private bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MachineRaycast();
    }

    private void MachineRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") && canShoot)
            {
                var obj = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                canShoot = false;
                Invoke("delayShoot", 1f);
            }
        }
    }

    void delayShoot()
    {
        canShoot = true;
    }

     private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = shootPoint.TransformDirection(Vector3.forward)* rayDistance;
        Gizmos.DrawRay(shootPoint.position, direction);
        //Gizmos.DrawLine(shootPoint.position, direction); ESTE GIZMO NO AFECTA LA ROTACION
    }
}
