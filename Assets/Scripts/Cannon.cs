using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float DelaySpawn = 1f;
    public float IntervalSpawn = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBala",DelaySpawn,IntervalSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBala()
    {
        Vector3 startPosition = this.transform.position + new Vector3(-2f,0f,0f);
        Instantiate(BulletPrefab, startPosition,BulletPrefab.transform.rotation);
    }
}
