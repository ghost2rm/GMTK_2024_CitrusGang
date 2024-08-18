using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInteractable : Interactables
{
    // Start is called before the first frame update
    void Start()
    {
        interactAction.AddListener(Spin);
    }

    void Spin()
    {
        this.transform.Rotate(0, 0, -90f);
        Debug.Log("spin: " + transform.eulerAngles.z);
    }
}
