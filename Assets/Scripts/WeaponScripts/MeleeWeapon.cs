using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public LayerMask enemyLayer;

    protected override void Attack()
    {
        base.Attack();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, data.range, enemyLayer);
        foreach (var enemy in enemies)
        {
            Debug.Log("Düşmana vuruldu: " + enemy.name);
            enemy.GetComponent<Enemy>()?.TakeDamage(data.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data != null ? data.range : 1f);
    }
}
