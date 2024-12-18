using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public InputRef inputRef;
    public GameObject panelPause;

    void Awake()
    {
        inputRef.PauseEvent += Pause;

        InicializeGameManager();
    }

    private void InicializeGameManager()
    {
         if(gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameManager getInstance()
    {
        return gameManager;
    }

    private void Pause()
    {
        panelPause.SetActive(true);
    }
}
