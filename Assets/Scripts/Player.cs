using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShootableTank
{
    protected override void Move()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
}
