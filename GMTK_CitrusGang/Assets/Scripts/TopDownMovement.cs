using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 topMovement;
    // Update is called once per frame
    void Update()
    {
        //Input

        //Horizontal Movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            topMovement.x += -1.0f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            topMovement.x += 1.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            topMovement.x -= -1.0f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            topMovement.x -= 1.0f;
        }


        //Vertical movement
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            topMovement.y += -1.0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            topMovement.y += 1.0f;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            topMovement.y -= -1.0f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            topMovement.y -= 1.0f;
        }


    }


    void FixedUpdate()
    {
        //Movement

        rb.MovePosition(rb.position + topMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
