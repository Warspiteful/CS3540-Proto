using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

// ReSharper disable SuggestVarOrType_BuiltInTypes

public class RatController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private Animator RatAnimator;

    private Vector3 velocity;
    public float gravity = -9.8f;
    public float jumpHeightWithoutGravity = 2f;
    public float speed = 4f;
    public float runSpeed = 7f;
    public bool isHidden;
    public bool grounded;

    public GameObject vignette;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void WasSpotted()
    {
        if (!isHidden)
        {
            Debug.Log("Rat seen, dead! Back to start point");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // vignette effect in shadow
    public void ToggleVignette(bool isHidden)
    {
        if (isHidden)
        {
            vignette.SetActive(true);
            vignette.GetComponent<RawImage>().CrossFadeAlpha(1.0f, 0.3f, false);
        }
        else
        {
            // vignette.SetActive(false);
            vignette.GetComponent<RawImage>().CrossFadeAlpha(0.0f, 0.2f, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Transform cameraTransform = mainCamera.transform;
        var sprinting = Input.GetKey(KeyCode.LeftShift);

        // if sprinting 
        // {
        //     animationController.is
        // }

        //Movement
        float x = Input.GetAxis("Horizontal");
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        float z = Input.GetAxis("Vertical");


        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z);
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        var currSpeed = sprinting ? runSpeed : this.speed;

        if (currSpeed == runSpeed)
        {
            RatAnimator.SetBool("isRunning", true);
            RatAnimator.SetBool("isWalking", false);
        }
        else if (currSpeed == speed && movement.magnitude > 0)
        {
            Debug.Log("is walking");
            RatAnimator.SetBool("isWalking", true);
            RatAnimator.SetBool("isRunning", false);
        }
        else
        {
            RatAnimator.SetBool("isWalking", false);
            RatAnimator.SetBool("isRunning", false);
        }
        
        controller.Move(currSpeed * Time.deltaTime * movement);

        //Rotate alongside the camera
        playerTransform.rotation = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up);
        //Gravity and Jumping
        if (!grounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // constantly push slightly into the ground so character controller grounded works
            velocity.y = gravity * .01f;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeightWithoutGravity);
        }
        RatAnimator.SetBool("isJumping", !grounded);

        controller.Move(velocity * Time.deltaTime);
        grounded = controller.isGrounded;
    }
    
    // Called when a collider is triggered
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemObject item))
        {
            item.OnHandlePickupItem();
        }
    }
    
}