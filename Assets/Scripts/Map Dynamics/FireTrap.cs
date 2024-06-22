using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : Trap
{
    float _onStayDamage = 5f;
    private Coroutine damageCoroutine;

    private void Awake()
    {
        damage = 20f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamageable>() != null)
        {
            damageCoroutine = StartCoroutine(DealDamageOnStay(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator DealDamageOnStay(Collider2D collision)
    {
        while (true)
        {
            if (collision.GetComponent<IDamageable>() != null)
            {
                collision.GetComponent<IDamageable>().TakeDamage(_onStayDamage);
            }
            yield return new WaitForSeconds(1);
        }
    }
}

