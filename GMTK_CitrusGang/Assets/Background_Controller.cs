using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Background_Controller : MonoBehaviour
{
    private float startPos, length;
    public GameObject _camera;
    public float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //calculate distance background moves based on camera movement
        float distance = _camera.transform.position.x * parallaxEffect;
        float movement = _camera.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        //if background exceeds bounds, adjust position for infinite scrolling
        if (movement > startPos + length) startPos += length;
        else if (movement < startPos - length) startPos -= length;
    }
}
