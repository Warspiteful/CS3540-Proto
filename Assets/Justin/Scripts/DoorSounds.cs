using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSounds : MonoBehaviour
{
   private AudioSource _source;

[SerializeField]   private AudioClip _clip;
   public void Start()
   {
      _source = GetComponent<AudioSource>();
   }

   public void PlayDoorOpening()
   {
      _source.clip = _clip;
      _source.Play();
   }

   public void StopSound()
   {
      _source.Stop();
   }
}
