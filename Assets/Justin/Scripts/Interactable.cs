using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] private UnityEvent onInteract;

    [SerializeField] private bool canInteract;
    
    [SerializeField] private Condition lockCondition;


    private void Start()
    {
        canInteract = false;
    }

    private void Update()
    {
        if(canInteract)
        {
            if(lockCondition == null || lockCondition.isComplete())
                if (Input.GetButtonDown("Interact"))
                {
                    Interact();
                }
        }
        
    }
    public void Interact()
    {
        
        onInteract?.Invoke();
        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            canInteract = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
    
}
