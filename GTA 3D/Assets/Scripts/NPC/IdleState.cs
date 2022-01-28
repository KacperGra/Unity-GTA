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

    public override void Initalize()
    {
        _timer = new Timer(Random.Range(_minIdleTime, _maxIdleTime));
        _npc.AnimationController.SetSpeed(0f, 1f);
    }

    public override State RunCurrentState()
    {
        _timer.Update(Time.deltaTime);

        if (_timer.TimerEnd)
        {
            return _moveToPoint;
        }

        return this;
    }
}