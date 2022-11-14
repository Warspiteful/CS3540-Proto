using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RobotSound : MonoBehaviour
{

    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip detectionSound;
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayWalkingSound()
    {
        source.PlayOneShot(walkingSound);
    }
    
    public void PlayDetectionSound()
    {
        source.PlayOneShot(detectionSound);
    }
}
