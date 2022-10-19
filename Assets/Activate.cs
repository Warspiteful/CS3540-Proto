using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject toActivate;

    public bool onByDefault;

    private void Start()
    {
        toActivate.SetActive(onByDefault);
    }

    private void OnTriggerEnter(Collider other)
    {
        toActivate.SetActive(!onByDefault);
    }

    private void OnTriggerExit(Collider other)
    {
        toActivate.SetActive(onByDefault);
    }
}
