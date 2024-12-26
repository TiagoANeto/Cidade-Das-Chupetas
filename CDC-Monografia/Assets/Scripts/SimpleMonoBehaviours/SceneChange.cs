using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
   public string sceneName;

   public void OnTriggerEnter2D(Collider2D other)
   {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Colidiu Aqui");
            SceneManager.LoadScene(sceneName);
        }
   } 
}
