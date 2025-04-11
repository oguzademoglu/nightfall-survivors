using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpAmount = 1;
    public float moveSpeed = 5f;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<PlayerXP>(out var playerXP))
            {
                playerXP.GainXP(xpAmount);
            }

            Destroy(gameObject);
        }
    }
}

