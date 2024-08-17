using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] private bool m_held;
    public bool held
    {
        get => m_held;
        private set => m_held = value;
    }

    public void PickupObj(GameObject obj)
    {
        MaryMovement grab = obj.GetComponent<MaryMovement>();
        
        if (grab == null)
        {
            return;
        }
        else
        {
            this.transform.SetParent(grab.grabPoint);
            Debug.Log("grabbed");
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            held = true;
        }
    }

   public void DropObject()
   {
       if (held == true)
       {
           this.transform.SetParent(null);
           this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
           held = false;
       }
       else
       {
           Debug.Log("dropped");
   
       }
   }
}
