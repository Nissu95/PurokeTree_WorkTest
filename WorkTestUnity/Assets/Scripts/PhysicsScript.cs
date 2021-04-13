using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    [SerializeField] string floorTag;

    Vector2 velocity = Vector2.zero;
    RaycastHit2D hit2D;
    float yv = 0;

    void FixedUpdate()
    {
        hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.05f);

        if (hit2D.collider != null)
        {
            if (hit2D.transform.tag == floorTag)
            {
                SetVelocityY(0);
                if (velocity.x > 0)
                    AddForceX(-GameManager.instance.GetDeceleration());
                else
                    SetVelocityX(0);
            }
        }
        else
            AddForceY(-GameManager.instance.GetGravity());

        transform.Translate(velocity * Time.fixedDeltaTime);
    }

    public void AddForce(float x, float y)
    {
        velocity.x += x;
        velocity.y += y;
    }

    public void AddForceX(float x)
    {
        velocity.x += x;
    }

    public void AddForceY(float y)
    {
        velocity.y += y;
    }

    public void SetVelocity(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    public void SetVelocityX(float x)
    {
        velocity.x = x;
    }

    public void SetVelocityY(float y)
    {
        velocity.y = y;
    }
}
