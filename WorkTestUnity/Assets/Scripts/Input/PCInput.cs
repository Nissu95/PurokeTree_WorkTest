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
                if (Input.GetAxis("Horizontal") < -deadZone || Input.GetAxis("Horizontal") > deadZone)
                {
                    inputState = InputState.Down;
                }
                break;

            case InputState.Down:
                inputState = InputState.Held;
                break;

            case InputState.Held:
                if (Input.GetAxis("Horizontal") > -deadZone && Input.GetAxis("Horizontal") < deadZone)
                {
                    inputState = InputState.Up;
                }
                break;

            case InputState.Up:
                inputState = InputState.Idle;
                break;
        }
    }

    public override bool GetInputDown()
    {
        if (inputState == InputState.Down)
            return true;
        else
            return false;
    }

    public override bool GetInputUp()
    {
        if (inputState == InputState.Up)
            return true;
        else
            return false;
    }

    public override float GetMoveInput()
    {
        return moveInput;
    }

}
