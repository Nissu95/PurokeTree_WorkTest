using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInput
{
    protected enum InputState
    {
        Idle,
        Down,
        Held,
        Up
    }

    protected InputState inputState;
    protected float moveInput;

    public virtual void Update() { }

    public bool GetInputDown()
    {
        if (inputState == InputState.Down)
            return true;
        else
            return false;
    }

    public bool GetInputUp()
    {
        if (inputState == InputState.Up)
            return true;
        else
            return false;
    }

    public float GetMoveInput()
    {
        return moveInput;
    }
}
