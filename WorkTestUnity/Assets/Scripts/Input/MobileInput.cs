using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : GeneralInput
{
    float deadZone = 0.02f;

    public override void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (Screen.width / 2))
                moveInput = 1;
            if (touch.position.x < (Screen.width / 2))
                moveInput = -1;
        }
        else
            moveInput = 0;

        switch (inputState)
        {
            case InputState.Idle:
                if (moveInput < -deadZone || moveInput > deadZone)
                {
                    inputState = InputState.Down;
                }
                break;

            case InputState.Down:
                inputState = InputState.Held;
                break;

            case InputState.Held:
                if (moveInput > -deadZone && moveInput < deadZone)
                {
                    inputState = InputState.Up;
                }
                break;

            case InputState.Up:
                inputState = InputState.Idle;
                break;
        }
    }
}
