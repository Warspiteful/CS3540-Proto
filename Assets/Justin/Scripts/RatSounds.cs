using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RatSounds : MonoBehaviour
{
    private AudioSource _source;

    [SerializeField] private float soundTime;
    
    [SerializeField] private AudioClips ratFootsteps;
        [SerializeField] private AudioClips ratRunning;
        [SerializeField] private AudioClips ratJump;
        [SerializeField] private AudioClips OnLand;

        private bool wasRunning;
        private void Start()
        {
            wasRunning = false;
            _source = GetComponent<AudioSource>();
        }


        void Update()
    {
        soundTime -= Time.deltaTime;
    }

    public void PlayBiteSound()
    {
        
    }
    

    public void PlayFootsteps()
    {
        if(soundTime <= 0 || wasRunning){
            Tuple<AudioClip, float> pickedClip = ratFootsteps.PickRandom();
                _source.PlayOneShot(pickedClip.Item1);
                soundTime = pickedClip.Item2;
                wasRunning = false;
        }
    }
    
    public void PlayRunning()
    {
        if(soundTime <= 0 || !wasRunning){
            Tuple<AudioClip, float> pickedClip = ratRunning.PickRandom();
            _source.PlayOneShot(pickedClip.Item1);
            soundTime = pickedClip.Item2;
            wasRunning = true;
        }
    }

    public void PlayJump()
    {
        Tuple<AudioClip, float> pickedClip = ratJump.PickRandom();
            _source.PlayOneShot(pickedClip.Item1);
            soundTime = pickedClip.Item2;
        
    }
    
    public void PlayOnLand()
    {
        Tuple<AudioClip, float> pickedClip = ratJump.PickRandom();
        _source.PlayOneShot(pickedClip.Item1);
        soundTime = pickedClip.Item2;
        
    }
}
