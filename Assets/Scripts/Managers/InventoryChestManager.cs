using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChestManager : MonoBehaviour
{
    [SerializeField] int capacidad = 5;
    List<GameObject> items;

    private void Awake()
    {
        items = new List<GameObject>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(GameObject item)
    {
        if (items.Capacity < capacidad)
        {
            items[items.Capacity] = item;
        }
        else
        {
            Debug.Log("Has superado el limite");
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (items.Capacity != 0)
        {
            items.Remove(item);
        }
        else
        {
            Debug.Log("El chest esta vacio");
        }
    }
}
