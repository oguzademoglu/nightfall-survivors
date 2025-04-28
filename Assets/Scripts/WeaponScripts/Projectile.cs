using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public LayerMask enemyLayer;
    private float damage;
    private Vector2 direction;

    public void Initialize(float damage, Vector2 direction)
    {
        this.damage = damage;
        this.direction = direction.normalized;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * (Vector3)direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}