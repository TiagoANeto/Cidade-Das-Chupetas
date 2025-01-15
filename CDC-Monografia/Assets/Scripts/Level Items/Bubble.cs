using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //bubble bubble bubble gum - haerin, newjeans

    public Animator anim;
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other){
        anim.SetTrigger("Collected");
        anim.SetTrigger("Explode");
        audioSource.Play();
        Destroy(gameObject, 0.3f);
    }
}
