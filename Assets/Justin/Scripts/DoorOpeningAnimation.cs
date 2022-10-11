using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningAnimation : MonoBehaviour
{

    [SerializeField] private Transform door;
    [SerializeField] private Transform endDestination;
    [SerializeField] private float speed;
    [SerializeField] private bool unlocked;
    [SerializeField] private Vector3 target;
    // Start is called before the first frame update


    public void OpenDoor()
    {
        unlocked = true;
    }
    
    private void Update()
    {
        if(unlocked){
            transform.position = Vector3.MoveTowards(door.position, target, Time.deltaTime * speed);
        }
    }

}
