using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class AudioClips : ScriptableObject
{
   [SerializeField] private AudioClip[] _clips;
   
   public Tuple<AudioClip, float> PickRandom()
   {
      AudioClip clip = _clips[Random.Range(0, _clips.Length)];
      return new Tuple<AudioClip, float>(clip, clip.length);
   }

  
}
