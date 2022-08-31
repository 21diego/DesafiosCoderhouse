using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] Mesh[] listMesh;
    enum FruitTypes { Apple, Banana, Cherries, Pear };
    [SerializeField] FruitTypes fruit;
    // Start is called before the first frame update
    void Start()
    {
        GameObject child = transform.GetChild(0).gameObject;
        MeshFilter meshChild = child.GetComponent<MeshFilter>();
        switch(fruit){
            case FruitTypes.Apple:
                meshChild.mesh = listMesh[0];
                child.tag = "Apple";
                break;
            case FruitTypes.Banana:
                meshChild.mesh = listMesh[1];
                child.tag = "Banana";
                break;
            case FruitTypes.Cherries:
                meshChild.mesh = listMesh[2];
                child.tag = "Cherries";
                break;
            case FruitTypes.Pear:
                meshChild.mesh = listMesh[3];
                child.tag = "Pear";
                break;
        }

        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
