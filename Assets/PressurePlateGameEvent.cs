using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.Shapes;

public class PressurePlateGameEvent : MonoBehaviour
{
    private int collisions;

    [SerializeField]
    private GameObject door;

    private Animator doorAnimator;
    
    private UnityEvent event1;
    private UnityEvent event2;


    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
        collisions = 0;
        https://youtu.be/15n-ilpYqME
        Gizmos.DrawLine(this.transform.position, doorAnimator.transform.position);

    }

    private void Update()
    {
        Debug.DrawLine(this.transform.position, door.transform.position, Color.magenta);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (collisions == 0)
        {
            doorAnimator.Play("DoorAnimation");
        }
        collisions += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        collisions -= 1;
        if (collisions == 0)
        {
            doorAnimator.Play("DoorClose");

        }
    }
}
