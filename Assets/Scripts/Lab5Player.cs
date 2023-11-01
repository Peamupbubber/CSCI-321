using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Player : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimMovement();
    }

    private void AnimMovement()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
            anim.SetBool("Running", true);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            anim.SetBool("Running", false);

        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
    }
}
