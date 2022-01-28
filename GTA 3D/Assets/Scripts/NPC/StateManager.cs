using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State _currentState;

    private void Awake()
    {
        _currentState.Initalize();
    }

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();
        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        if (_currentState != nextState)
        {
            nextState.Initalize();
        }
        _currentState = nextState;
    }
}