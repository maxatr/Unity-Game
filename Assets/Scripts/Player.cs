using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private float _timer;

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        UI.UpdateHp(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

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
