using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic
{
    private float _value;
    private float _maxValue;

    public float Value => _value;
    public float MaxValue => _maxValue;

    public Statistic(float maxValue)
    {
        _maxValue = maxValue;
        _value = maxValue;
    }

    public void ChangeAmount(int value)
    {
        _value += value;
        if (_value < 0)
        {
            _value = 0;
        }
        else if (_value > _maxValue)
        {
            _value = _maxValue;
        }
    }

    public void SetValue(float value)
    {
        _value = value;
    }

    public void SetMaxValue(float maxValue)
    {
        _maxValue = maxValue;
    }
}