using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RobotMovement : MonoBehaviour
{

    public Transform start;
    public Transform end;
    public float moveTime;
    public float rotationSpeed;
    private float currTime = 0;
    private float soundTime = 0;


    [SerializeField] private AudioSource _source;

    [SerializeField] private AudioClips robotWalk;

    [SerializeField] private FieldOfView fov;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        var t = transform;
        t.position = start.position;

    }

    // Update is called once per frame
    void Update()
    {
        var t = transform;
        currTime += Time.deltaTime;
        soundTime -= Time.deltaTime;
        
        if(!fov.isRatFound())
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

        if (soundTime <= 0)
        {
            Tuple<AudioClip, float> pickedClip = robotWalk.PickRandom();
            _source.PlayOneShot(pickedClip.Item1);
            soundTime = pickedClip.Item2;
        }

        if (currTime >= moveTime * 2)
        {
            currTime = 0;
        }
    }
    
    
}
