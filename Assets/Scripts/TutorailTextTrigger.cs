using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorailTextTrigger : MonoBehaviour
{
    public GameObject text1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        text1.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left");
        text1.SetActive(false);
    }
}
