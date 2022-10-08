using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            text.CrossFadeAlpha(1, 1, false);

            text.enabled = true;
            Debug.Log("entered " + text.name);
            triggered = true;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        text.CrossFadeAlpha(0, 1, false);

        if (other.CompareTag("Player"))
        {
            //text.enabled = true;
            triggered = true;

            Debug.Log("left " + text.name);
        }
    }
}
