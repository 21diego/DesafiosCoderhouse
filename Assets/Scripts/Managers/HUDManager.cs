using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }
    [SerializeField] private Slider hpBar;

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
    }

    public static void SetHPBar(int newValue)
    {
        instance.hpBar.value = newValue;
        if (instance.hpBar.value < 60){
            instance.hpBar.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(177, 200, 0, 225);
        }
        if (instance.hpBar.value <= 20){
            instance.hpBar.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(224, 27, 0, 225);
        }
    }
}
