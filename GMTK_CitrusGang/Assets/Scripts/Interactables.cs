using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
    public bool inRange = false;
    public bool m_isInteracting = false;
    [SerializeField]KeyCode mInteract = KeyCode.F; //Mary's interact keycode
    [SerializeField]KeyCode lInteract = KeyCode.RightControl; //Larry's interact keycode
    public UnityEvent interactAction;
    public UnityEvent stopAction;
    

    public bool IsInteracting
    {
        get => m_isInteracting;
        set => m_isInteracting = value;
    }

    private void Update()
    {
        if (inRange && !IsInteracting) //If player is in range
        {
            if (Input.GetKeyDown(mInteract)) //If Mary interacts
            {
                interactAction.Invoke(); //Fire Event
            }

            if (Input.GetKeyDown(lInteract)) //If Larry interacts
            {
                Debug.Log("we in business");
                interactAction.Invoke(); //Fire event
            }
        }

        //If a character is holding something, call this instead
        else if(IsInteracting)
        {
            
            if (Input.GetKeyDown(mInteract)) //If Mary interacts
            {
                Debug.Log("Stop Interacting");
                stopAction.Invoke(); //Fire Event
            }

            if (Input.GetKeyDown(lInteract)) //If Larry interacts
            {
                stopAction.Invoke(); //Fire event
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Larry"))
        {
            inRange = true;
            Debug.Log("Larry is in range");
        }

        if (collision.gameObject.CompareTag("Mary"))
        {
            inRange = true;
            Debug.Log("Mary is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Larry"))
        {
            inRange = false;
        }

        if (collision.gameObject.CompareTag("Mary"))
        {
            inRange = false;
        }
    }
}
