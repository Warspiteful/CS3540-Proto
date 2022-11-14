using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float height = 1;
    public float smooth;
    public float radius = 2f;
    
    // void OnDrawGizmos()
    // {
    //     var rat = transform;
    //     
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawRay(transform.position, transform.forward );
    //     //Draw a cube that extends to where the hit exists
    //     Gizmos.DrawWireSphere(rat.position + rat.forward, radius);
    // }
    
    // Update is called once per frame
    // based on this tutorial: https://www.youtube.com/watch?v=runW-mf1UH0
    void Update () {
        var rat = transform;
        if(carrying) {
            // carriedObject.transform.position = 
            //     Vector3.Lerp (
            //         carriedObject.transform.position, 
            //         rat.position + rat.forward * distance + rat.up * height, 
            //         Time.deltaTime * smooth);
            var rigidBody = carriedObject.GetComponent<Rigidbody>();
            rigidBody
                .MovePosition(Vector3.Lerp (
                    carriedObject.transform.position, 
                    rat.position + rat.forward * distance + rat.up * height, 
                    Time.deltaTime * smooth));
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            carriedObject.transform.rotation = Quaternion.identity;
            if(Input.GetKeyDown (KeyCode.E)) {
                carrying = false;
                carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        } else {
            if(Input.GetKeyDown (KeyCode.E)) {
                
                var hits = Physics.SphereCastAll(rat.position + rat.forward, radius, rat.forward, radius);
                var hitIndex = Array.FindIndex(hits, hit => hit.transform.tag == "Pickupable");
                if(hitIndex != -1)
                {
                    var hit = hits[hitIndex];
                    var hitObject = hit.transform.gameObject;
                    Debug.Log(hitObject.name);
                    if (hitObject.CompareTag("Pickupable"))
                    {
                        carriedObject = hitObject;
                        carrying = true;
                        carriedObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
    }
    
}
