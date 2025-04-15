using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Nightfall/Skill")]
public class SkillData : ScriptableObject
{
    [Header("Genel Bilgiler")]
    public string skillName;
    [TextArea]
    public string description;
    public Sprite icon;

    [Header("Yetenek Tipi ve Değeri")]
    public SkillType type;
    public float value;

    [Header("Özelleştirme")]
    public bool isStackable = false; // Aynı yetenek birden fazla alınabilir mi?
}

public enum SkillType
{
    Passive,    // Örn: %20 attack speed
    Active      // Örn: Anında dash, area explosion, vb.
}