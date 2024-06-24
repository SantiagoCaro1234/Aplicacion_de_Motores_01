using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField] private Entity entity;

    [SerializeField] private float knockbackForce = 35f;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {           
            print($"{this.gameObject} collision with {collision.gameObject.name}");

            Vector2 knockBackDirection = (collision.transform.position - transform.position).normalized;

            collision.attachedRigidbody.AddForce(knockBackDirection * knockbackForce, ForceMode2D.Impulse);

            entity.Die();
        }
    }
}
