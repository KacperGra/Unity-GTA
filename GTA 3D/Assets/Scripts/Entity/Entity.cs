using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float _startingHealth;
    [SerializeField] protected Statistic _health;

    private void Start()
    {
        _health = new Statistic(_startingHealth);
    }

    public void TakeDamage(int value)
    {
        _health.ChangeAmount(-value);
        if (_health.Value <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        ;
    }
}