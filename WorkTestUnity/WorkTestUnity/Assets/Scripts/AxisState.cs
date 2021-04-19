using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisState
{
    enum eAxisState
    {
        Idle,
        Down,
        Held,
        Up
    }

    float deadZone = 0.02f;
    eAxisState axisState;

    public void Update()
    {
        switch (axisState)
        {
            case eAxisState.Idle:
                if (Input.GetAxis("Horizontal") < -deadZone || Input.GetAxis("Horizontal") > deadZone)
                {
                    axisState = eAxisState.Down;
                }
                break;

            case eAxisState.Down:
                axisState = eAxisState.Held;
                break;

            case eAxisState.Held:
                if (Input.GetAxis("Horizontal") > -deadZone && Input.GetAxis("Horizontal") < deadZone)
                {
                    axisState = eAxisState.Up;
                }
                break;

            case eAxisState.Up:
                axisState = eAxisState.Idle;
                break;
        }
    }

    public bool GetAxisDown()
    {
        if (axisState == eAxisState.Down)
            return true;
        else
            return false;
    }

    public bool GetAxisUp()
    {
        if (axisState == eAxisState.Up)
            return true;
        else
            return false;
    }

}
