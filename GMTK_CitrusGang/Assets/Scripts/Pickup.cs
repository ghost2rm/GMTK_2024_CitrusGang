using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Interactables thisBox;
    BoxCollider2D hardBox;
    MaryMovement grab;
    //[SerializeField] private GameObject newCollisionBox; //Change the collison box to a larger size to match the holding box animation.

    //Pick up this box


    public void PickupObj(GameObject obj)
    {
        thisBox = this.gameObject.GetComponent<Interactables>(); //Get this boxes interacatable status. 
        hardBox = this.GetComponents<BoxCollider2D>()[1];
        grab = obj.GetComponent<MaryMovement>();
        
        
        if (grab == null)
        {
            return;
        }
        else
        {

            //Set position to the grab points, set to kinematic then parent.
            this.transform.position = grab.grabPoint.position;
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            hardBox.isTrigger = true; //Disables hard collisions on the box
            grab.modCollider.enabled = true;
            this.transform.position = grab.grabPoint.position;
            this.transform.SetParent(grab.grabPoint);
            thisBox.IsInteracting = true;


            Debug.Log("grabbed");
            
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
        hardBox.isTrigger = false;
        grab.modCollider.enabled = false;

        Debug.Log("dropped");   
   }
}
