using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] private UnityEvent onInteract;

    [SerializeField] private bool canInteract;


    private void Update()
    {
        if(canInteract)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }
        
    }
    public void Interact()
    {
        
        onInteract?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
    
}
