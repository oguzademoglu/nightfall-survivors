using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public LayerMask enemyLayer;

    protected override void Attack()
    {
        base.Attack();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, data.range * 1.5f, enemyLayer);
        // foreach (var enemy in enemies)
        // {
        //     Debug.Log("Düşmana vuruldu: " + enemy.name);
        //     enemy.GetComponent<Enemy>()?.TakeDamage(data.damage);
        // }
        foreach (var enemyCol in enemies)
        {
            if (enemyCol.TryGetComponent<Enemy>(out var enemy))
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemyCol.bounds.center);

                if (distanceToEnemy <= data.range)
                {
                    Debug.Log($"Düşmana vuruldu: {enemy.name} | Mesafe: {distanceToEnemy:F2}");
                    enemy.TakeDamage(data.damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data != null ? data.range : 1f);
    }
}
