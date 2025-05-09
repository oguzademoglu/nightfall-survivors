using Unity.Cinemachine;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public LevelUpUI levelUpUI;
    public CinemachineCamera virtualCamera;
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
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            SkillManager skillManager = FindAnyObjectByType<SkillManager>();
            playerStats.characterData = GameData.selectedCharacter;
            skillManager.playerStats = playerStats;

            PlayerXP xp = player.GetComponent<PlayerXP>();
            if (xp != null && levelUpUI != null)
            {
                xp.levelUpUI = levelUpUI;
            }
            // 🎥 Kamera hedefini karakter yap
            if (virtualCamera != null)
            {
                virtualCamera.Follow = player.transform;
            }
        }
        else
        {
            Debug.LogWarning("Karakter verisi yok! Ana menüden seçim yapılmamış olabilir.");
        }
    }
}
