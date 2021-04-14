using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationGuide : MonoBehaviour
{
    [SerializeField] GameObject locationGuide;
    [SerializeField] LayerMask layerMask;

    RaycastHit2D hit2DRight;

    /*private void FixedUpdate()
    {
        hit2DRight = Physics2D.Raycast(transform.position, Vector2.right, 8.0f, layerMask);

        Debug.DrawRay(transform.position, Vector2.right);

        if (hit2DRight.collider != null)
        {
            if (hit2DRight.transform.tag == "Floor")
            {
                Debug.Log("asdadas");
            }
        }
    }*/
}
