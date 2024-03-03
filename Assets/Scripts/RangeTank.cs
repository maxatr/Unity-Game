using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float distanceToPlayer = 5f;
    private float _timer;
    private Transform _target;

    protected override void Start()
    {
        base.Start();

        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * (movementSpeed * Time.deltaTime));
    }

    protected void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > distanceToPlayer)
        {
            Move();
        }

        SetAngle(_target.position);
        
        if (_timer <= 0)
        {
            Shoot();

            _timer = reloadTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
