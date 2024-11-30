using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    
    public string nomeDaCena;
    public GameObject panelMenuInicial;
    public GameObject panelCredits;

   public void ButtonPlay()
    {
        SceneManager.LoadScene("LevelDesign");
    }

    public void ButtonOpenCredits()
    {
        panelMenuInicial.SetActive(false);
        panelCredits.SetActive(true);
    }

    public void ButtonCloseCredits()
    {
        panelCredits.SetActive(false);
        panelMenuInicial.SetActive(true);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

