using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public float _currentHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        print($"{gameObject.name}'s Health: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print($"{gameObject.name} has died");
    }
}
