using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private float attackTimer;

    [Header("Attack Settings")]
    public float attackRate = 1f; // Saniyede kaç saldırı
    public float attackRange = 1.5f; // Saldırı yarıçapı
    public float attackDamage = 10f; // Verilecek hasar
    public float pushbackForce = 0.5f;
    public LayerMask enemyLayer; // Hangi layer'daki objelere vuracak
    public GameObject hitEffectPrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= 1f / attackRate)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attackTrigger"); // Animator'a saldırı tetikleyici yolla
    }

    // Bu metod, attack animasyonu içindeki Animation Event'ten çağrılacak
    public void PerformAttack()
    {
        Debug.Log("PerformAttack() tetiklendi!");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (var enemyCollider in hitEnemies)
        {
            Enemy enemy = enemyCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Düşmana vuruldu: " + enemy.name);
            }
            // 🎯 Hit Effect spawn
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, enemy.transform.position, Quaternion.identity);
            }
            // 🎯 Pushback
            enemy.ApplyPushback(transform.position, pushbackForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
