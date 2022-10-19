using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private RatController rat;
    
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
        Debug.Log("rat entered");

        if (other.tag == "Player")
        {
            rat = other.gameObject.GetComponent<RatController>();
            rat.isHiden = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {   
            rat = other.gameObject.GetComponent<RatController>();
            rat.isHiden = false;
        }
    }
}
