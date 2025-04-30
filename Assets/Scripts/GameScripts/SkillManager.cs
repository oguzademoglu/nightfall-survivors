using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("Referanslar")]
    public PlayerStats playerStats;

    // [Header("Pasif Skill İkonları")]
    // public Transform passiveSkillIconContainer;
    // public GameObject passiveSkillIconPrefab;

    [Header("Aktif Skill Kontrolü")]
    private SkillData activeSkill;
    private float cooldownTimer = 0f;
    private bool canUseActiveSkill = false;

    void Update()
    {
        if (activeSkill != null)
        {
            if (!canUseActiveSkill)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0f)
                {
                    canUseActiveSkill = true;
                }
            }

            if (canUseActiveSkill && Input.GetKeyDown(KeyCode.Q))
            {
                UseActiveSkill();
            }
        }
    }

    public void ApplySkill(SkillData skill)
    {
        Debug.Log($"[SkillManager] Uygulanan Yetenek: {skill.skillName}");

        // Pasif yetenekler
        if (skill.type == SkillType.Passive)
        {
            switch (skill.skillName)
            {
                case "Hızlı Saldırı":
                    playerStats.attackSpeed += skill.value;
                    break;

                case "HP +50":
                    playerStats.Heal((int)skill.value);
                    break;

                case "Hareket Hızı Artışı":
                    playerStats.moveSpeed += skill.value;
                    break;

                default:
                    Debug.LogWarning($"[SkillManager] Tanınmayan pasif skill: {skill.skillName}");
                    break;
            }

            // AddPassiveIcon(skill.icon);
        }

        // Aktif yetenekler (örnek: Mezar Toprağı)
        else if (skill.type == SkillType.Active && skill.skillPrefab != null)
        {
            activeSkill = skill;
            canUseActiveSkill = true;
            cooldownTimer = 0f;

            Debug.Log($"[SkillManager] Aktif skill atandı: {skill.skillName}");
        }
    }

    private void UseActiveSkill()
    {
        for (int i = 0; i < activeSkill.numberToSpawn; i++)
        {
            Vector2 spawnPos = (Vector2)playerStats.transform.position + Random.insideUnitCircle * activeSkill.spawnRadius;
            Instantiate(activeSkill.skillPrefab, spawnPos, Quaternion.identity);
        }

        cooldownTimer = activeSkill.cooldown; // skill.value = cooldown süresi
        canUseActiveSkill = false;

        Debug.Log($"[SkillManager] Aktif skill kullanıldı: {activeSkill.skillName}");
    }

    // private void AddPassiveIcon(Sprite icon)
    // {
    //     if (passiveSkillIconContainer == null || passiveSkillIconPrefab == null) return;

    //     GameObject newIcon = Instantiate(passiveSkillIconPrefab, passiveSkillIconContainer);
    //     newIcon.GetComponent<UnityEngine.UI.Image>().sprite = icon;
    // }
}
