using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarryMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float hMove = 0f;

    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    //Update is called a fixed amount 
    private void FixedUpdate()
    {
        //Move Character 
        controller.Move(hMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
