using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PoisonFilter : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    ColorGrading poisonFilter;

    private void OnEnable()
    {
        FindObjectOfType<EnemySpider>().OnPoisoned += PoisonFilterEffect;
    }
    // Start is called before the first frame update
    void Start()
    {
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out poisonFilter);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PoisonFilterEffect()
    {
        Debug.Log("Se activa");
        poisonFilter.active = true;
        Invoke("DisabledFilter",1f);
    }


    public void DisabledFilter()
    {
        Debug.Log("Se desactiva");
        poisonFilter.active = false;
    }
}
