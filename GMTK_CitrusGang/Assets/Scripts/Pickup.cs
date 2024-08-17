using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Interactables thisBox;

    //Pick up this box
    public void PickupObj(GameObject obj)
    {
        thisBox = this.gameObject.GetComponent<Interactables>(); //Get this boxes interacatable status. 


        MaryMovement grab = obj.GetComponent<MaryMovement>();
        
        if (grab == null)
        {
            return;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(grab.grabPoint);
            Debug.Log("grabbed");
            thisBox.IsInteracting = true;
        }
    }

    //Grab world position, unparent the box, set rigid body to Dynamic, set world transform
   public void DropObject()
   {
        Vector2 currentWorldPos = this.transform.position;
        this.transform.SetParent(null);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        this.transform.position = currentWorldPos;
        thisBox.IsInteracting = false;
        Debug.Log("dropped");   
   }
}
