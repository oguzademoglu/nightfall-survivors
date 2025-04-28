using UnityEngine;

public class RangedWeapon : WeaponBase
{
    public Transform firePoint; // Merminin çıkacağı nokta

    protected override void Attack()
    {
        base.Attack();

        if (data.projectilePrefab == null || firePoint == null) return;

        // Mermiyi oluştur
        GameObject proj = Instantiate(data.projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projectile = proj.GetComponent<Projectile>();

        if (projectile != null)
        {
            Vector2 direction = firePoint.right * Mathf.Sign(transform.lossyScale.x);
            projectile.Initialize(data.damage, direction);
        }
    }
}