using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    [SerializeField] private Transform m_grabPoint;

    public Transform grabPoint
    {
        get => m_grabPoint;
        private set => m_grabPoint = value;
    }


    Vector2 topMovement;

    // Update is called once per frame
    void Update()
    {
        //Input

        //Horizontal Movement
        #region
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
        #endregion

        //Vertical movement
        #region
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
        #endregion

    }

    //Called 50 times p/s by default
    void FixedUpdate()
    {
        //Movement

        rb.MovePosition(rb.position + topMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
