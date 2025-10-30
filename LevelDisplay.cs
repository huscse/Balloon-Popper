using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    private TMP_Text levelText;

    void Awake()
    {
        levelText = GetComponent<TMP_Text>();

        // Get the current scene index
        int index = SceneManager.GetActiveScene().buildIndex;
        string sceneName = SceneManager.GetActiveScene().name;

        // Display name and index nicely
        levelText.text = $"Level {index + 1}";
        Debug.Log($"Now playing: {sceneName} (index {index})");
    }
}
