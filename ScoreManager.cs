using UnityEngine;
using TMPro;   // for TMP_Text

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // global access
    public TMP_Text scoreText;           
    private int score = 0;

    void Awake()
    {
        // simple singleton pattern
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
