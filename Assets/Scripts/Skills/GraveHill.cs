using UnityEngine;

public class GraveHill : MonoBehaviour
{
    public float rootDuration = 2f; // Kaç saniye rootlansın

    private void Start()
    {
        Destroy(gameObject, 5f); // 5 saniye sonra otomatik sil
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ISStatusEffect root = other.gameObject.AddComponent<RootEffect>();
            root.Apply(other.gameObject, rootDuration);
        }
    }
}
