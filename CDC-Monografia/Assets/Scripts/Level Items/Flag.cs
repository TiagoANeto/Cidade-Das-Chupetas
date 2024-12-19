using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Animator anim;
    void OnTriggerEnter2D(Collider2D other){
        anim.SetTrigger("FlagUp");
    }
}
