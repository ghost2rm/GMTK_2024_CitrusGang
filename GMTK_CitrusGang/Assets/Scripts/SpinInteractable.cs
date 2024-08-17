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

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spin()
    {
        this.transform.Rotate(0, 0, 90f);
    }
}
