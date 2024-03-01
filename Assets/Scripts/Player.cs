using UnityEngine;

public class Player : ShootableTank
{
    private float _timer;
    
    protected override void Move()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Rigidbody.velocity = direction.normalized * movementSpeed;
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (_timer <= 0)
        {
            if (!Input.GetMouseButton(0))
            {
                return;
            }
            
            Shoot();
            _timer = reloadTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
