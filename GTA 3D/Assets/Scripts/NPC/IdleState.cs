using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private MoveToPointState _moveToPoint;
    [SerializeField] private NPC _npc;

    [Title("Settings")]
    [SerializeField] private float _minIdleTime = 0f;
    [SerializeField] private float _maxIdleTime = 8f;

    private Timer _timer = null;
    private bool _timerEnd;

    public override State RunCurrentState()
    {
        if (_timer == null)
        {
            _timer = new Timer(Random.Range(_minIdleTime, _maxIdleTime));
            _timer.OnTimerEnd += () =>
            {
                _timerEnd = true;
            };
        }
        else
        {
            _timer.Update(Time.deltaTime);
        }

        if (_timerEnd)
        {
            ResetState();
            return _moveToPoint;
        }

        _npc.AnimationController.SetSpeed(0f, 1f);

        return this;
    }

    public void ResetState()
    {
        _timer = null;
        _timerEnd = false;
    }
}