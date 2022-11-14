using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RatSound : MonoBehaviour
{

    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip idleSound;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayWalkingSound()
    {
        source.PlayOneShot(walkSound);
    }
    
    public void PlayIdleSound()
    {
        source.PlayOneShot(idleSound);
    }
    

}
