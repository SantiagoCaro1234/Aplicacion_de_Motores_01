using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Entity
{
    [SerializeField, Range(5f, 30f)] private float _knockbackDamage = 10f;

    [SerializeField, Range(1f, 10f)] private float _knockbackRadius;
    [SerializeField, Range(1f, 100f)] private float _knockbackForce = 75f;

    private void Awake()
    {
        _currentHealth = 50f;
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    private void Knockback(GameObject originalCollision)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _knockbackRadius);

        foreach (Collider2D collider in objects)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                //Debug.Log("BOMBA");
                Vector2 dir = collider.transform.position - transform.position;
                float distance = 1 + dir.magnitude;
                float finalForce = _knockbackForce / distance;
                rb2D.AddForce((dir * finalForce).normalized, ForceMode2D.Impulse);

                Player player = collider.GetComponent<Player>();
                if (player)
                {
                    player.TakeDamage(_knockbackDamage);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _knockbackRadius);
    }
}
