using System;
using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int damage = 5;
    private Transform _target;
    private float _timer = 5f;
    private float _hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * (movementSpeed * Time.deltaTime));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        
        if (player && _timer <= 0)
        {
            player.TakeDamage(damage);

            _timer = _hitCooldown;
        }
    }

    private void Update()
    {
        if (_target)
        {
            if (_timer <= 0)
            {
                Move();
                SetAngle(_target.position);
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }
}
