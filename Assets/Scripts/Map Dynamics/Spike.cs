using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : Trap
{   
    private void Awake()
    {
        knockbackForce = 10f;
        damage = 15f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage);
        }

        if (collision.attachedRigidbody != null)
        {          
            Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;
            
            collision.attachedRigidbody.AddForce(knockBackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
