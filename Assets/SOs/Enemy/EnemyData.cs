using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Nightfall/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float moveSpeed;
    public GameObject prefab;
    public int xpReward;
}