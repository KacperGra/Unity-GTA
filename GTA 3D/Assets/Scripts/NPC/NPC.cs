using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Human
{
    [SerializeField] private HumanAnimationController _animationController;
    [SerializeField] private NavMeshAgent _agent;

    public HumanAnimationController AnimationController => _animationController;
    public NavMeshAgent Agent => _agent;

    public override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}