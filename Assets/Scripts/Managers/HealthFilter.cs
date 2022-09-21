using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthFilter : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    Vignette healthFilter;

    private void OnEnable()
    {
        FindObjectOfType<PlayerMechanics>().OnLastLife += LastLife;
    }
    // Start is called before the first frame update
    void Start()
    {
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out healthFilter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LastLife()
    {
        Debug.Log("Llegando a ultima vida");
        healthFilter.active = true;
    }
}
