using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable SuggestVarOrType_BuiltInTypes

public class RatController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    private Vector3 velocity;
    private float gravity = -9.8f;
    public float jumpHeightWithoutGravity = 2f;
    public float speed = 5f;
    public float maxDistanceToJump = 0.6f;

    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        //Grounded
        grounded = Physics.Raycast(playerTransform.position, Vector3.down, maxDistanceToJump);
        
        //Movement
        float x = Input.GetAxis("Horizontal");
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        float z = Input.GetAxis("Vertical");
        
        
        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z);
        controller.Move(movement * (speed * Time.deltaTime));
        
        //Gravity and Jumping
        velocity.y += gravity * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeightWithoutGravity);
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
