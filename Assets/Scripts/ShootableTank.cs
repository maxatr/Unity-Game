using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;

    protected void Shoot()
    {
        Instantiate(_projectile, _shootPoint.position, transform.rotation);
    }
}
