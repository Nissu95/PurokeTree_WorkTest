using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    enum State { Right = 1,
                Idle = 0,
                Left = -1}

    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    
    float moveInput;
    float currentSpeed = 0;
    State state = 0;
    
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        switch (moveInput)
        {
            case 1:

                if (currentSpeed < maxSpeed)
                    currentSpeed += acceleration * Time.fixedDeltaTime;
                else
                    currentSpeed = maxSpeed;

                state = (State)moveInput;
                transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                break;
            case 0:
                switch (state)
                {
                    case State.Right:
                        if (currentSpeed > 0)
                            currentSpeed -= acceleration * Time.fixedDeltaTime;
                        else
                        {
                            currentSpeed = 0;
                            state = 0;
                        }

                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    case State.Idle:
                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    case State.Left:
                        if (currentSpeed < 0)
                            currentSpeed += acceleration * Time.fixedDeltaTime;
                        else
                        {
                            currentSpeed = 0;
                            state = 0;
                        }

                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    default:
                        break;
                }
                break;
            case -1:

                if (currentSpeed > -maxSpeed)
                    currentSpeed -= acceleration * Time.fixedDeltaTime;
                else
                    currentSpeed = -maxSpeed;

                state = (State)moveInput;
                transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                break;
        }
    }
}
