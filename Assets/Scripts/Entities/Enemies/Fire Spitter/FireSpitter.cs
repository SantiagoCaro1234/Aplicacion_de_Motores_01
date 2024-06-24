using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpitter : Entity
{
    // References
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _bulletPrefab;
    Coroutine _shootingCoroutine;

    // Values
    [SerializeField, Range(1f, 5f)] private float _shootingCooldown;

    private void Awake()
    {
        _currentHealth = 1000f;
    }

    private void Start()
    {
        _shootingCoroutine = StartCoroutine(Shooting());
    }

    private void Shoot()
    {
        //Debug.Log("Shot");
        Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootingCooldown);
        }
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }
}
