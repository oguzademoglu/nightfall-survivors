using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;

    private float currentHealth;
    private Transform player;


    [SerializeField] private GameObject xpOrbPrefab;
    // [SerializeField] private int xpAmount = 1;

    void Start()
    {
        Initialize(data);
    }

    public void Initialize(EnemyData enemyData)
    {
        data = enemyData;
        currentHealth = data.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += data.moveSpeed * Time.deltaTime * (Vector3)direction;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{data.enemyName} öldü!");
        if (xpOrbPrefab != null)
        {
            GameObject xp = Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
            xp.GetComponent<XPOrb>().xpAmount = data.xpReward;
        }
        Destroy(gameObject);
    }
}