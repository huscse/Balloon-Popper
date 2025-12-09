using UnityEngine;
using TMPro;
using System.Text;

public class HighScoresManagerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoresText;  // link this in Inspector

    private void Start()
    {
        if (scoresText == null)
        {
            Debug.LogError("ScoresText is not assigned on HighScoresManagerUI!");
            return;
        }

        if (HighScoreManager.Instance == null)
        {
            scoresText.text = "No high scores yet.";
            return;
        }

        var scores = HighScoreManager.Instance.GetScores();

        if (scores.Count == 0)
        {
            scoresText.text = "No high scores yet.";
            return;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("High Scores:");
        for (int i = 0; i < scores.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {scores[i]}");
        }

        scoresText.text = sb.ToString();
    }
}
