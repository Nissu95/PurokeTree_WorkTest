using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float timer = 0;
    float time;

    public void SetTime(float _time)
    {
        time = _time;
        Reset();
    }

    public void Reset()
    {
        timer = time;
    }

    public bool TimeUp()
    {
        if (timer <= 0)
            return true;
        else
            return false;
    }

    public void Update()
    {
        timer -= Time.fixedDeltaTime;
    }

    public float GetTimer()
    {
        return timer;
    }
}
