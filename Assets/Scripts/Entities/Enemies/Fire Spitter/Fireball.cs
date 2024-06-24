using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField, Range(5f, 30f)] private float _fireballDamage = 15f;

    [SerializeField, Range(1f, 10f)] private float _explosionRadius;
    [SerializeField, Range(1f, 100f)] private float _explosionForce = 75f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>())
        {
            Knockback(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Knockback(GameObject originalCollision)
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (Collider2D collider in objects)
        {
            Rigidbody2D rb2D = collider.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                //Debug.Log("BOMBA");
                Vector2 dir = collider.transform.position - transform.position;
                float distance = 1 + dir.magnitude;
                float finalForce = _explosionForce / distance;
                rb2D.AddForce((dir * finalForce).normalized, ForceMode2D.Impulse);

                Player player = collider.GetComponent<Player>();
                if (player)
                {
                    player.TakeDamage(_fireballDamage);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
