using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public AudioSource audioSource;    
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void VolumeController(float value)
    {
        audioSource.volume = value;
    }
}
