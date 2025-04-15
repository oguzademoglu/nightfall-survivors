using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelUpUI levelUpUI;
    void Start()
    {
        if (GameData.selectedCharacter != null)
        {
            if (GameData.selectedCharacter.characterPrefab == null)
            {
                Debug.LogError("Character prefab atanmadı!");
                return;
            }
            GameObject player = Instantiate(GameData.selectedCharacter.characterPrefab, Vector3.zero, Quaternion.identity);
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.characterData = GameData.selectedCharacter;

            PlayerXP xp = player.GetComponent<PlayerXP>();
            if (xp != null && levelUpUI != null)
            {
                xp.levelUpUI = levelUpUI;
            }
        }
        else
        {
            Debug.LogWarning("Karakter verisi yok! Ana menüden seçim yapılmamış olabilir.");
        }
    }
}
