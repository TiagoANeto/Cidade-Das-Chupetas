using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public InputRef inputRef;
    public GameObject panelPause;
    public Animator animator;

    void Awake()
    {
        inputRef.PauseEvent += Pause;

        InicializeGameManager();

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        panelPause = GameObject.Find("/Canvas/PauseMenu");
        animator = GameObject.Find("/CanvasTransition/Transitions").GetComponent<Animator>();

        if(panelPause != null) {panelPause.SetActive(false);}
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

    public void NextLevel()
    {
        StartCoroutine(LoadLevelScene());
    }

    IEnumerator LoadLevelScene()
    {
        animator.SetTrigger("EndLevel");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        animator.SetTrigger("StartLevel");
    }
}
