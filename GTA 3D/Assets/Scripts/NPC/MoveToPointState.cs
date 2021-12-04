using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPointState : State
{
    [SerializeField] private NPC _npc;
    [SerializeField] private IdleState _idle;

    private Transform _currentTarget;
    private bool _firstRun;

    public override State RunCurrentState()
    {
        if (_firstRun)
        {
            _firstRun = false;

            /*if (_currentTarget != null)
            {
                _currentTarget = GameManager.Instance.MapManager.GetNextPoint(_currentTarget);
            }
            else
            {
                _currentTarget = GameManager.Instance.MapManager.GetNearestPoint(transform);
            }*/

            if (RandomPoint(transform.position, 5f, out var result))
            {
                _npc.Agent.SetDestination(result);
                _npc.AnimationController.SetSpeed(2f, 1f);
                return this;
            }

            //_npc.Agent.SetDestination(_currentTarget.position);

            return _idle;
        }

        Debug.Log(_npc.Agent.remainingDistance);
        if (_npc.Agent.remainingDistance < 1f)
        {
            _npc.Agent.ResetPath();

            ResetState();
            return _idle;
        }

        return this;
    }

    private void ResetState()
    {
        _firstRun = true;
    }

    private static bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;

        return false;
    }
}