using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    public Transform start;
    public Transform end;
    public float moveTime;

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
        currTime += Time.deltaTime/(moveTime);
        if (currTime <= moveTime)
        {
            transform.position = Vector3.Lerp(start.position, end.position, currTime);
        }
        else
        {
            transform.position = Vector3.Lerp(end.position, start.position, currTime - moveTime);
        }

        if (currTime >= moveTime * 2)
        {
            currTime = 0;
        }
    }
}
