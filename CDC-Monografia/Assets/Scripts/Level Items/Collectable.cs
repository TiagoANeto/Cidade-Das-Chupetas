using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject bubblePath;
    public Animator anim;

    void OnTriggerEnter2D (Collider2D other){
        bubblePath.SetActive(true); //ativa o caminho de bolhas
        anim.SetTrigger("Collected"); //roda a animacao de coletado
        Destroy(gameObject, 1f); //destroi o objeto....
    }

}