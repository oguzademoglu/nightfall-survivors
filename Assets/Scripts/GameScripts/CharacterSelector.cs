using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public CharacterData knightData;
    public CharacterData rogueData;

    public void SelectKnight()
    {
        GameData.selectedCharacter = knightData;
        SceneManager.LoadScene("GameScene");
    }

    public void SelectRogue()
    {
        GameData.selectedCharacter = rogueData;
        SceneManager.LoadScene("GameScene");
    }
}
