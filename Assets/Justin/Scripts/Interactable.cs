using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] private UnityEvent onInteract;

    [SerializeField] private bool canInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }

}
