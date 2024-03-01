using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 5f;
    [SerializeField] private string myTag = "";

    private void Update()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
}
