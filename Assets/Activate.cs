using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject toActivate;

    public bool onByDefault;

    private int collisions;

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
