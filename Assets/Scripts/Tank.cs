using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private int points = 0;
    [SerializeField] protected float movementSpeed = 3f;
    [SerializeField] protected float angleOffset = 90f;
    [SerializeField] protected float rotationSpeed = 7f;
    protected UI UI;
    protected Rigidbody2D Rigidbody;
    protected int CurrentHealth;

    protected virtual void Start()
    {
        CurrentHealth = maxHealth;
        Rigidbody = GetComponent<Rigidbody2D>();
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Stats.Score += points;
            UI.UpdateScoreAndLevel();
            Destroy(gameObject);
        }
    }

    protected abstract void Move();

    protected void SetAngle(Vector3 target)
    {
        var deltaPosition = target - transform.position;
        var angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        var angle = Quaternion.Euler(0f, 0f, angleZ + angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * rotationSpeed);
    }
}
