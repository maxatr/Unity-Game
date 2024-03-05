using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private string projectileTag;
    [SerializeField] private Transform shootPoint;
    [SerializeField] protected float reloadTime = 0.5f;
    private ObjectPooler _objectPooler;
    
    protected void Shoot()
    {
        Instantiate(projectile, shootPoint.position, transform.rotation);
    }
}
