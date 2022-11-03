using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressurePlateGameEvent : MonoBehaviour
{
    public GameObject toActivate;

    public bool onByDefault;

    private int collisions;


    
    private UnityEvent event1;
    private UnityEvent event2;

    private void Start()
    {
        toActivate.SetActive(onByDefault);
        collisions = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        toActivate.SetActive(!onByDefault);
        collisions += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        collisions -= 1;
        if (collisions == 0)
        {
            toActivate.SetActive(onByDefault);
        }
    }
}
