using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public PlayerStats playerStats;

    public void ApplySkill(SkillData skill)
    {
        Debug.Log($"[SkillManager] Uygulanan Yetenek: {skill.skillName}");

        switch (skill.skillName)
        {
            case "Hızlı Saldırı":
                playerStats.attackSpeed += skill.value;
                Debug.Log($"[PlayerStats] Yeni saldırı hızı: {playerStats.attackSpeed}");
                break;

            case "HP +50":
                playerStats.Heal((int)skill.value);
                Debug.Log($"[PlayerStats] HP Yenilendi: {skill.value}");
                break;

            case "Hareket Hızı Artışı":
                playerStats.moveSpeed += skill.value;
                Debug.Log($"[PlayerStats] Yeni hareket hızı: {playerStats.moveSpeed}");
                break;

            default:
                Debug.LogWarning($"[SkillManager] Tanınmayan skill: {skill.skillName}");
                break;
        }
    }
}


