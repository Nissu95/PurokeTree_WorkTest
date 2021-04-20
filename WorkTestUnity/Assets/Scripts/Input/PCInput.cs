using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : GeneralInput
{
    float deadZone = 0.02f;

    public override void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

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
