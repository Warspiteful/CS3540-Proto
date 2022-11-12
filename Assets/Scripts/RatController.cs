using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ReSharper disable SuggestVarOrType_BuiltInTypes

public class RatController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Camera mainCamera;

    private Vector3 velocity;
    private float gravity = -9.8f;
    private float jumpHeightWithoutGravity = 2f;
    public float speed = 5f;
    public float runSpeed = 10f;
    public float maxDistanceToJump;
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
    public void ToggleVignette(bool isHiden)
    {
        if (isHiden)
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
        //Grounded
        grounded = Physics.Raycast(playerTransform.position, Vector3.down, maxDistanceToJump);

        //Movement
        float x = Input.GetAxis("Horizontal");
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        float z = Input.GetAxis("Vertical");


        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z);
        if (movement.magnitude > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(movement * runSpeed * Time.deltaTime);
            }
            else
            {
                controller.Move(movement * speed * Time.deltaTime);
            }
        }

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

    // Called when a collider is triggered
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemObject item))
        {
            item.OnHandlePickupItem();
        }
    }
}