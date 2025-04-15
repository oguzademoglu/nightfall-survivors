using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpUI : MonoBehaviour
{
    public GameObject panel;
    public List<SkillData> allSkills;

    [System.Serializable]
    public class SkillCard
    {
        public Button button;
        public Image icon;
        public TMP_Text nameText;
        public TMP_Text descriptionText;
    }

    public List<SkillCard> skillCards = new();

    private void Start()
    {
        panel.SetActive(false);
    }

    public void ShowSkillOptions()
    {
        panel.SetActive(true);

        List<SkillData> randomSkills = GetRandomSkills(3);

        for (int i = 0; i < skillCards.Count; i++)
        {
            int index = i;
            SkillData skill = randomSkills[i];
            skillCards[i].icon.sprite = skill.icon;
            skillCards[i].nameText.text = skill.skillName;
            skillCards[i].descriptionText.text = skill.description;

            skillCards[i].button.onClick.RemoveAllListeners();
            skillCards[i].button.onClick.AddListener(() =>
            {
                ApplySkill(skill);
                panel.SetActive(false);
            });
        }
    }

    private List<SkillData> GetRandomSkills(int count)
    {
        List<SkillData> copy = new(allSkills);
        List<SkillData> result = new();
        for (int i = 0; i < count; i++)
        {
            if (copy.Count == 0) break;
            int randomIndex = Random.Range(0, copy.Count);
            result.Add(copy[randomIndex]);
            copy.RemoveAt(randomIndex);
        }
        return result;
    }

    private void ApplySkill(SkillData skill)
    {
        // Skill uygulama burada yapılır
        Debug.Log($"Yetenek Seçildi: {skill.skillName}");

        if (skill.type == SkillType.Passive)
        {
            // örnek: attack speed artır
        }
        else if (skill.type == SkillType.Active)
        {
            // örnek: patlama hasarı ver
        }
    }
}
