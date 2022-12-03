using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RobotSound : MonoBehaviour
{

    [SerializeField] private AudioClip detectionSound;
    [SerializeField] private AudioSource oneShotSource;

    private void Start()
    {
        oneShotSource = GetComponent<AudioSource>();
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
