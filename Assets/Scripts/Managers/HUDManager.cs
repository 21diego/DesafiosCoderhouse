using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }
    [SerializeField] private Slider hpBar;
    private Dictionary<string, Color32> statusHPColor;
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
}
