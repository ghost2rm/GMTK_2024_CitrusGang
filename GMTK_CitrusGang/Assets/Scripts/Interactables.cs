using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{
    bool inRange = false;
    KeyCode mInteract = KeyCode.F; //Mary's interact keycode
    KeyCode lInteract = KeyCode.RightControl; //Larry's interact keycode
    public UnityEvent interactAction;
    public UnityEvent dropAction;

    private void Update()
    {

        if (inRange) //If player is in range
        {
            if (Input.GetKeyDown(mInteract) || Input.GetKeyDown(lInteract)) //If Mary or larry interact
            {
                interactAction.Invoke(); //Fire Event
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
