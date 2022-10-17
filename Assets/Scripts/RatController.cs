using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable SuggestVarOrType_BuiltInTypes

public class RatController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Camera mainCamera;
    
    private Vector3 velocity;
    private float gravity = -9.8f;
    private float jumpHeightWithoutGravity = 2f;
    public float speed = 5f;
    public float maxDistanceToJump;

    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Transform cameraTransform = mainCamera.transform;
        //Grounded
        grounded = Physics.Raycast(playerTransform.position, Vector3.down, maxDistanceToJump);
        
        //Movement
        float x = Input.GetAxis("Horizontal");
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        float z = Input.GetAxis("Vertical");
        
        
        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z);
        controller.Move(movement * (speed * Time.deltaTime));
        
        //Rotate alongside the camera
        playerTransform.rotation = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up);
        //Gravity and Jumping
        if (!grounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeightWithoutGravity);
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
