using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float damage = 10f;
    public float attackRate = 1f; // saniyede kaç saldırı yapar

    protected float attackCooldown;
    protected WeaponData data;

    public virtual void Initialize(WeaponData weaponData)
    {
        data = weaponData;
    }

    protected virtual void Update()
    {
        data.attackCooldown -= Time.deltaTime;

        if (data.attackCooldown <= 0f)
        {
            Attack();
            data.attackCooldown = 1f / data.attackRate;
        }
    }

    protected virtual void Attack()
    {
        // Debug.Log("Saldırı yapıldı!");
        // Saldırı davranışı alt sınıfta yazılacak
    }
}
