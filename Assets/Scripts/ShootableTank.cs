using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private string projectileTag;
    [SerializeField] private Transform shootPoint;
    [SerializeField] protected float reloadTime = 0.5f;
    private ObjectPooler _objectPooler;

    protected override void Start()
    {
        base.Start();
        _objectPooler = ObjectPooler.Instance;
    }

    protected void Shoot()
    {
        _objectPooler.SpawnFromPool(projectileTag, shootPoint.position, transform.rotation);
    }
}
