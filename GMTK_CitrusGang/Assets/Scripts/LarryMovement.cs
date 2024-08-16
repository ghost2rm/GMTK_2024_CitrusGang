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
       

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        //Using GetAxisRaw makes it impossible to 

        if (Input.GetKeyDown(KeyCode.A))
        {
            hMove += -1.0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            hMove += 1.0f;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            hMove -= -1.0f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            hMove -= 1.0f;
        }

    }

    //Update is called a fixed amount 
    private void FixedUpdate()
    {
        //Move Character 
        controller.Move((hMove * runSpeed) * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
