using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    [SerializeField] float timeToRecycle;
    [SerializeField] int value = 1;

    Vector2 velocity = Vector2.zero;
    Timer timer = new Timer();
    RaycastHit2D hit2D;
    LocationGuide locationGuide;

    bool lastBounce = false;

    void Start()
    {
        timer.SetTime(timeToRecycle);
        locationGuide = GetComponent<LocationGuide>();
    }

    void OnEnable()
    {
        SetVelocity(Vector2.zero);
        transform.rotation = Quaternion.identity;
        lastBounce = false;
        timer.Reset();
    }

    void FixedUpdate()
    {
        hit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.05f);

        if (!lastBounce)
        {
            if (hit2D.collider != null)
            {
                switch (hit2D.transform.tag)
                {
                    case "Floor":
                        timer.Update();
                        SetVelocityY(0);
                        locationGuide.SetIsVisible(false);
                        locationGuide.Deactivate();

                        if (velocity.x > 0)
                            AddForceX(-GameManager.instance.GetDeceleration());
                        else
                            SetVelocityX(0);
                        if (timer.TimeUp())
                            GetComponent<PoolObject>().Recycle();
                        break;
                    case "Player":
                        SetVelocityY(velocity.y * -hit2D.collider.GetComponent<SpringBoxScript>().GetVerticalBounceFactor());
                        SetVelocityX(velocity.x * hit2D.collider.GetComponent<SpringBoxScript>().GetHorizontalBounceFactor());
                        break;
                    case "Goal":
                        Score();
                        break;
                }
            }
            else
                AddForceY(-GameManager.instance.GetGravity());
        }
        else
        {
            SetVelocity(0, 0);
            Transform target = GameManager.instance.GetGoalTrans();
            SetVelocity(target.position - transform.position);

            if (hit2D.collider != null && hit2D.transform.tag == "Goal")
                Score();
        }

        transform.Translate(velocity * Time.fixedDeltaTime);
    }

    void Score()
    {
        locationGuide.SetIsVisible(false);
        GameManager.instance.AddRockAmount(value);
        GetComponent<PoolObject>().Recycle();
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

    public void SetVelocity(float x, float y)
    {
        velocity.x = x;
        velocity.y = y;
    }

    public void SetVelocityX(float x)
    {
        velocity.x = x;
    }

    public void SetVelocityY(float y)
    {
        velocity.y = y;
    }

    public void IsLastBounce(bool _LastBounce)
    {
        lastBounce = _LastBounce;
    }
}
