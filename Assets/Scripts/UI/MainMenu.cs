using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void OnClickPlay()
    {
        Debug.Log("SE PRESIONO EL BOTON PLAY");
        //SceneManager.LoadScene("Level0");
        SceneManager.LoadScene("Desafio11UI");
    }
}
