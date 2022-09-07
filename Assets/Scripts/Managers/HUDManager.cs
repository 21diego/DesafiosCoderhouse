using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject panelInventory;
    private Dictionary<string, Color32> statusHPColor;
    private Dictionary<string, TextMeshProUGUI> itemsCount;
    private Image fillHPImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        statusHPColor = new Dictionary<string, Color32>(){
            {"safe", new Color32(89, 202, 54, 225)},
            {"warning", new Color32(177, 200, 0, 225)},
            {"danger", new Color32(224, 27, 0, 225)},
        };

        fillHPImage = instance.hpBar.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();

        itemsCount = new Dictionary<string, TextMeshProUGUI>();

        //Momentaneamente cargo los 4 items. Ver si se puede hacer de manera dinamica
        itemsCount["Apple"] = instance.panelInventory.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemsCount["Banana"] = instance.panelInventory.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemsCount["Cherries"] = instance.panelInventory.transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemsCount["Pear"] = instance.panelInventory.transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }


    public static void SetHPBar(int newValue)
    {
        instance.hpBar.value = newValue;

        if (instance.hpBar.value >= 75)
        {
            instance.fillHPImage.color = instance.statusHPColor["safe"];
        }
        if (instance.hpBar.value < 75 && instance.hpBar.value > 30)
        {
            instance.fillHPImage.color = instance.statusHPColor["warning"];
        }
        if (instance.hpBar.value <= 30)
        {
            instance.fillHPImage.color = instance.statusHPColor["danger"];
        }
    }

    public static void SetInventoryItem(string fruit, int count)
    {
        instance.itemsCount[fruit].text = "x" + count;
    }

    void ConsoleOutput()
    {
        foreach (KeyValuePair<string, TextMeshProUGUI> kvp in itemsCount)
            Debug.Log("Key = "+ kvp.Key + " --> Value = " + kvp.Value);
    }
}
