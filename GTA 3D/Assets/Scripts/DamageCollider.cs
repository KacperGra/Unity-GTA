using System;
using System.Collections;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public Action<int> OnTakeDamage;

    public void TakeDamage(int damage)
    {
        OnTakeDamage?.Invoke(damage);
    }
}