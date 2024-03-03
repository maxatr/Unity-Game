using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string myTag = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tank = collision.GetComponent<Tank>();

        if (tank != null && collision.gameObject.tag != myTag)
        {
            tank.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
}
