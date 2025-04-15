using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (GameData.selectedCharacter != null)
        {
            GameObject player = Instantiate(GameData.selectedCharacter.characterPrefab, Vector3.zero, Quaternion.identity);
            PlayerStats stats = player.GetComponent<PlayerStats>();
            stats.characterData = GameData.selectedCharacter;
        }
        else
        {
            Debug.LogWarning("Karakter verisi yok! Ana menüden seçim yapılmamış olabilir.");
        }
    }
}
