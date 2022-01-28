using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Action OnTimerEnd;
    public bool TimerEnd { get; private set; }

    private float _currentTime;
    private float _maxTime;

    public Timer(float time)
    {
        _currentTime = 0f;
        _maxTime = time;
        TimerEnd = false;
    }

    public void Update(float deltaTime)
    {
        _currentTime += deltaTime;
        if (_currentTime >= _maxTime)
        {
            TimerEnd = true;
            OnTimerEnd?.Invoke();
        }
    }
}