using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RobotSound : MonoBehaviour
{

    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip detectionSound;
    [SerializeField] private AudioSource oneShotSource;
    [SerializeField] private AudioSource loopingSource;

    private void Start()
    {
        oneShotSource = GetComponent<AudioSource>();
        loopingSource = GetComponent<AudioSource>();
    }

    public void PlayWalkingSound()
    {
        oneShotSource.PlayOneShot(walkingSound);
    }
    
    public void PlayWalkingSoundLoop()
    {
        loopingSource.clip = walkingSound;
        loopingSource.Play();
    }
    
    public void PlayDetectionSound()
    {
      
      oneShotSource.PlayOneShot(detectionSound);
      
    }

    public float GetDetectionLength()
    {
        return detectionSound.length;
    }
}
