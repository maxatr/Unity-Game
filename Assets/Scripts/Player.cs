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
        transform.Translate(Vector2.down * (Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime));
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
