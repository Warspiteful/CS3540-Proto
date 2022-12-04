using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement2 : RobotMovement
{   

    public float rotateSpeed = 60.0f;
    public float timeBetweenRotation = 5f;
    private bool rotating = false;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();

        StartCoroutine("ToggleRotation");
    }

    void Update()
    {
        animator.SetBool("walking", !rotating);
        if (!rotating)
        {
            base.Update();
        }
        else {
            float rotationAmount = rotateSpeed * Time.deltaTime;

            // Rotate the object around its up axis (the y-axis) by the specified amount
            transform.Rotate(transform.up, rotationAmount);
        }
    }

    IEnumerator ToggleRotation()
    {
        while (true)
        {
            rotating = true;
            yield return new WaitForSeconds(360 / rotateSpeed);
            rotating = false;
            yield return new WaitForSeconds(timeBetweenRotation);
        }


    }


}
