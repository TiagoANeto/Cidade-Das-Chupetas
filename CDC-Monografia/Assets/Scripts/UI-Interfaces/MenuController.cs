using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    
    public string nomeDaCena;
    public GameObject panelMenuInicial;
    public GameObject panelCredits;
    public GameObject panelSettings;

   public void ButtonPlay()
    {
        SceneManager.LoadScene(nomeDaCena);
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

    public void ButtonOpenSettings()
    {
        panelMenuInicial.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ButtonCloseSettings()
    {
        panelSettings.SetActive(false);
        panelMenuInicial.SetActive(true);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

