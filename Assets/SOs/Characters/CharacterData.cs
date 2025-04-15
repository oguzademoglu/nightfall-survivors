using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Nightfall/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite portrait;
    public GameObject characterPrefab;

    [Header("İstatistikler")]
    public float moveSpeed = 5f;
    public float attackSpeed = 1f;
    public int maxHP = 100;
}
