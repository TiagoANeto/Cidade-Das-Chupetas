using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    
    public string nomeDaCena;
    public GameObject panelMenu;
    public GameObject panelCredits;
    public GameObject panelSettings;

   public void ButtonPlay()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void ButtonOpenCredits()
    {
        panelMenu.SetActive(false);
        panelCredits.SetActive(true);
    }

    public void ButtonCloseCredits()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void ButtonOpenSettings()
    {
        panelMenu.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void ButtonCloseSettings()
    {
        panelSettings.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

