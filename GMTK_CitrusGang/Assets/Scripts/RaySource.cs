using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaySource : MonoBehaviour
{
    Vector2 rayPoint;
    Vector3 ray3;
    public UnityEvent FinishBeam;
    [SerializeField] LineRenderer lineDraw;
    private bool draw = false;

    // Start is called before the first frame update
    void Start()
    {
        switch (transform.eulerAngles.z)
        {
            case 90f:
                rayPoint = Vector2.left;
                break;
            case 0:
                rayPoint = Vector2.up;
                break;
            case 270f:
                rayPoint = Vector2.right;
                break;
            case 180f:
                rayPoint = Vector2.down;
                break;
            default:
                break;
        }
        ray3.x = rayPoint.x; ray3.y = rayPoint.y; ray3.z = 0;
        draw = this.CompareTag("Ray Source");
    }

    // Update is called once per frame
    void Update()
    {
        switch (transform.eulerAngles.z)
        {
            case 90f:
                rayPoint = Vector2.left;
                break;
            case 0:
                rayPoint = Vector2.up;
                break;
            case 270f:
                rayPoint = Vector2.right;
                break;
            case 180f:
                rayPoint = Vector2.down;
                break;
            default:
                break;
        }
        ray3.x = rayPoint.x; ray3.y = rayPoint.y; ray3.z = 0;
        if (this.CompareTag("Ray Source")) FireRay();
        lineDraw.enabled = draw;
        draw = false;
    }

    void FireRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayPoint);
        // Does the ray intersect any objects excluding the player layer
        if (hit.collider != null)
        {
            draw = true;
            if (hit.collider.CompareTag("Mirror"))
            {
                Debug.Log(hit.collider.gameObject.GetComponent<RaySource>().rayPoint);
                hit.collider.gameObject.GetComponent<RaySource>().FireRay();
            }
            if (lineDraw && lineDraw.positionCount == 2)
            {
                lineDraw.SetPosition(0, transform.position);
                lineDraw.SetPosition(1, hit.point);
            }
            Debug.DrawRay(transform.position, ray3 * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
    }
}
