using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    [SerializeField] protected float reloadTime = 0.5f;

    protected void Shoot()
    {
        Instantiate(projectile, shootPoint.position, transform.rotation);
    }
}
