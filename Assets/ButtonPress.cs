using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    
    public GameObject activatable;

    public AudioSource source;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = activatable.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSound()
    {
        source.Play();
    }

    public void ActivateDoor()
    {
        animator.SetBool("Activated", true);
    }
}
