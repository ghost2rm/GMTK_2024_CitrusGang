using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaryMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float hMove = 0f;

    bool jump = false;

    [SerializeField] private Transform m_grabPoint;
    [SerializeField] private BoxCollider2D m_modCollider; // A bigger collider for when Mary holds a box
    private bool m_stunned = false;


    public bool Stunned
    {
        get => m_stunned;
        set => m_stunned = value;
    }

    public BoxCollider2D modCollider
    {
        get => m_modCollider;
        private set => m_modCollider = value; 
    }

    public Transform grabPoint
    {
        get => m_grabPoint;
        private set => m_grabPoint = value;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetButtonDown("Jump") && !Stunned)
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

    //Called 50 times p/s by default
    private void FixedUpdate()
    {
        //Move Character 
        if (!Stunned)
        { 
            controller.Move((hMove * runSpeed) * Time.fixedDeltaTime, false, jump); 
        }
        jump = false;

    }
}
