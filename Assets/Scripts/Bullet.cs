using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _shootPoint;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _direction = new Vector2(-1, 0);

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public float Speed => _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        Destroy(gameObject, 4f);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
