using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Entity
{
    #region Patrol Related
    [SerializeField] GameObject _pointA;
    [SerializeField] GameObject _pointB;
    Rigidbody2D _rb;
    Transform _currentPoint;
    [SerializeField] private float _speed;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentPoint = _pointB.transform;
    }

    private void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if (_currentPoint == _pointB.transform)
        {
            _rb.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, 0);
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
        {
            Flip();
            _currentPoint = _pointA.transform;
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
        {
            Flip();
            _currentPoint = _pointB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(_pointB.transform.position, 0.5f);
        Gizmos.DrawLine(_pointA.transform.position, _pointB.transform.position);
    }

    public override void Die()
    {

        Destroy(this.gameObject);
    }
}
