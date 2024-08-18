using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteractable : Interactables
{
    //for things that need to read if the interactable is flipped
    private bool flipped = false;

    public bool IsFlipped
    {
        get => flipped;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactAction.AddListener(Flip);
    }

    void Flip()
    {
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        flipped = !flipped;
    }
}
