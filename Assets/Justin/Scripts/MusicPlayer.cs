using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip MainTheme;
    [SerializeField] private AudioClip LevelTheme;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame

    public void PlayMenuMusic()
    {
        source.clip = MainTheme;
        source.Play();   
    }

    public void PlayLevelMusic()
    {
        source.clip = LevelTheme;
        source.Play();
    }
}
