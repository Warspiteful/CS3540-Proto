using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Serialization;


public class PressurePlateGameEvent : MonoBehaviour
{
    private int collisions;

    [FormerlySerializedAs("door")] [SerializeField]
    private GameObject activatable;

    private Animator animator;
    
    private UnityEvent event1;
    private UnityEvent event2;

    public float distance = .1f;
    
    
    
    private void Start()
    {
        animator = activatable.GetComponent<Animator>();
        collisions = 0;
        //https://youtu.be/15n-ilpYqME

    }
    

    private void Update()
    {
        Debug.DrawLine(this.transform.position, activatable.transform.position, Color.magenta);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (collisions == 0)
        {
            animator.SetBool("Activated", true);
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
            animator.SetBool("Activated", false);

            transform.position += Vector3.up * distance;
            GetComponent<BoxCollider>().center -= Vector3.up * distance;

        }
    }
}
