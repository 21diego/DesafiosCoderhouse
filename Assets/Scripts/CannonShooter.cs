using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ShootNBullets(2);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShootNBullets(3);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShootNBullets(4);
        }
    }

    void ShootNBullets(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Invoke("InstantiateBullet",0.2f * i);
        }
    }

    void InstantiateBullet()
    {
        Vector3 startPosition = this.transform.position + new Vector3(-2f,0f,0f);
        Instantiate(bulletPrefab, startPosition, bulletPrefab.transform.rotation);
    }
}
