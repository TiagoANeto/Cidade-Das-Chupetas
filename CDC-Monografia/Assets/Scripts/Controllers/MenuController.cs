using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject panelCredits;
    public GameObject panelSettings;
    public AudioSource audioSource;

    public void ButtonPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonCredits()
    {
        if(panelCredits.activeInHierarchy == false)
        {
            panelCredits.SetActive(true);
        }
        else
        {
            panelCredits.SetActive(false);
        }
    }

    public void ButtonSettings()
    {
        if(panelSettings.activeInHierarchy == false)
        {
            panelSettings.SetActive(true);
        }
        else
        {
            panelSettings.SetActive(false);
        }
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
    
    public void AudioButton(){
        audioSource.Play();
    }
}

