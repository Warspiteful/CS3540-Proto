using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    public Transform start;
    public Transform end;
    public float moveTime;
    public float rotationSpeed;
    private float currTime = 0;

    
    // Start is called before the first frame update
    void Start()
    { 
        var t = transform;
        t.position = start.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        var t = transform;
        currTime += Time.deltaTime;
        if (currTime <= moveTime)
        {
            t.position = Vector3.Lerp(start.position, end.position, (currTime / moveTime));
            var direction = (end.position - t.position).normalized;
 
            //create the rotation we need to be in to look at the target
            var lookRotation = Quaternion.LookRotation(direction);
 
            //rotate us over time according to speed until we are in the required rotation
            t.rotation = Quaternion.Slerp(t.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(end.position, start.position, (currTime - moveTime) / moveTime);
            var direction = (start.position - t.position).normalized;
 
            //create the rotation we need to be in to look at the target
            var lookRotation = Quaternion.LookRotation(direction);
 
            //rotate us over time according to speed until we are in the required rotation
            t.rotation = Quaternion.Slerp(t.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

        if (currTime >= moveTime * 2)
        {
            currTime = 0;
        }
    }
}
