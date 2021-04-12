using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    [SerializeField] float gravity;

    Vector2 velocity = Vector2.zero;
    //RaycastHit2D hit2D;

    void FixedUpdate()
    {
        AddForceY(-gravity);

        //Physics2D.Raycast(transform, )

        transform.Translate(velocity);
    }

    public void AddForceX(float x)
    {
        velocity.x = x * Time.fixedDeltaTime;
    }

    public void AddForceY(float y)
    {
        velocity.y = y * Time.fixedDeltaTime;
    }

}
