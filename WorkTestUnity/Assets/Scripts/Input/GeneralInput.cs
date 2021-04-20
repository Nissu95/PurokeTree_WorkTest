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
    public virtual bool GetInputDown() { return false; }
    public virtual bool GetInputUp() { return false; }
    public virtual float GetMoveInput() { return 0; }
}
