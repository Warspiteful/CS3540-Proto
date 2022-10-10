using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// Forcefield stuff
// https://forum.unity.com/threads/best-way-to-get-swirling-noise.954993/


public class TutorailTextTrigger : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Bool to keep track of if the text has already been shown to the player.
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        // Some fading text code from:
        // https://youtu.be/Pg2H7SGSMJ4
        
        // start transparent
        text.CrossFadeAlpha(0, 0, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Show tutorial text when the player enters a trigger zone.
    // Text remains on screen for a few seconds, or disappears immediately when the player leaves that zone (so it won't overlap with other text).
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            text.CrossFadeAlpha(1, .5f, false);

            text.enabled = true;
            Debug.Log("entered " + text.name);
            triggered = true;
            
            StartCoroutine(FadeOut());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(text);
    }


    // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
    // Fade the text out after waiting a few seconds.
    IEnumerator FadeOut()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        if (text != null)
        {
            text.CrossFadeAlpha(0, 2, false);
        }
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
