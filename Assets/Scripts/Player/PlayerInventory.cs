using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<string, int> itemsPlayer;
    // Start is called before the first frame update

    private void Awake() {
        itemsPlayer = new Dictionary<string, int>();
    }

    public void AddItem(string item)
    {
        Debug.Log(item);
        if (itemsPlayer.ContainsKey(item))
        {
            int cantidad = itemsPlayer[item];
            cantidad++;
            itemsPlayer[item] = cantidad;
        }
        else
        {
            itemsPlayer[item] = 1;
        }

        ConsoleOutput();
    }

    void ConsoleOutput()
    {
        foreach (KeyValuePair<string, int> kvp in itemsPlayer)
            Debug.Log("Key = "+ kvp.Key + " --> Value = " + kvp.Value);
    }
        
}
