using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;

    private float currentHealth;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private Rigidbody2D rb;


    private bool isPushed = false;
    private readonly float pushRecoveryTime = 0.4f; // 0.2 saniyede eski haline dönecek
    private float pushTimer;


    private bool isRooted;


    [SerializeField] private GameObject xpOrbPrefab;
    // [SerializeField] private int xpAmount = 1;

    void Start()
    {
        Initialize(data);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Initialize(EnemyData enemyData)
    {
        data = enemyData;
        currentHealth = data.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    [System.Obsolete]
    void Update()
    {
        if (player == null) return;

        if (isPushed)
        {
            pushTimer -= Time.deltaTime;
            if (pushTimer <= 0f)
            {
                isPushed = false;
            }
            return;
        }

        if (isRooted)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        // transform.position += data.moveSpeed * Time.deltaTime * (Vector3)direction;
        rb.velocity = direction * data.moveSpeed;
        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
        else
        {
            StartCoroutine(Flash()); // 🎯 Hasar alırken flash yap
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

    private IEnumerator Flash()
    {
        spriteRenderer.color = Color.red; // Beyaza çevir
        yield return new WaitForSeconds(0.5f); // Çok kısa bir süre bekle
        spriteRenderer.color = originalColor; // Eski rengine dön
    }

    public void ApplyPushback(Vector2 sourcePosition, float pushForce)
    {
        Vector2 pushDirection = (transform.position - (Vector3)sourcePosition).normalized;
        // transform.position += (Vector3)(pushDirection * pushForce);
        rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

        isPushed = true;
        pushTimer = pushRecoveryTime;
    }

    public void SetRooted(bool value)
    {
        isRooted = value;
    }
}