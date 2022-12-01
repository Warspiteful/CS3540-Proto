using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject toActivate;

    public bool onByDefault;

    private int collisions;

    public float distance = .05f;

    private void Start()
    {
        toActivate.SetActive(onByDefault);
        collisions = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        toActivate.SetActive(!onByDefault);
        if (collisions == 0)
        {
            transform.position -= Vector3.up * distance;
            GetComponent<BoxCollider>().center += Vector3.up * distance;
        }
        collisions += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        collisions -= 1;
        if (collisions == 0)
        {
            toActivate.SetActive(onByDefault);
            transform.position += Vector3.up * distance;
            GetComponent<BoxCollider>().center -= Vector3.up * distance;
        }
    }
}
