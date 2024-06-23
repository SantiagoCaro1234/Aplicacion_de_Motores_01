using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField, Range(5f, 30f)] private float _fireballDamage = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>())
        {
            collision.GetComponent<Entity>().TakeDamage(_fireballDamage);
            Destroy(this.gameObject);
        }
    }
}
