using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterData characterData;

    [HideInInspector] public float moveSpeed;
    [HideInInspector] public float attackSpeed;
    [HideInInspector] public int maxHP;
    [HideInInspector] public int currentHP;

    private void Awake()
    {
        if (characterData != null)
        {
            moveSpeed = characterData.moveSpeed;
            attackSpeed = characterData.attackSpeed;
            maxHP = characterData.maxHP;
            currentHP = maxHP;
        }
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }

    public void ModifyMoveSpeed(float amount) => moveSpeed += amount;
    public void ModifyAttackSpeed(float amount) => attackSpeed += amount;
}
