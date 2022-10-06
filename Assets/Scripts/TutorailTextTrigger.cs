using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorailTextTrigger : MonoBehaviour
{
    public GameObject text;
    // Bool to keep track of if the text has already been shown to the player.
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            Debug.Log("entered " + text.name);
            text.SetActive(true);
            triggered = true;
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            triggered = true;

            Debug.Log("left " + text.name);
            text.SetActive(false);
        }

    }
}
