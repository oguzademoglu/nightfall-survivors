using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int currentLevel = 1;
    public int xpToNextLevel = 10;

    public LevelUpUI levelUpUI;

    public void GainXP(int amount)
    {
        currentXP += amount;
        Debug.Log("XP Kazanıldı: " + amount + " | Toplam: " + currentXP);

        if (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentXP = currentXP - xpToNextLevel;
        xpToNextLevel += 5; // seviye başına artış

        Debug.Log("Level Up! Yeni seviye: " + currentLevel);

        if (levelUpUI != null)
        {
            levelUpUI.ShowSkillOptions();
        }
        else
        {
            Debug.LogWarning("LevelUpUI bağlantısı yapılmamış!");
        }
    }
}
