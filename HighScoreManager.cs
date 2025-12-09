using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }

    public List<int> highScores = new List<int>();
    private const int MaxScores = 5;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScores();
    }

    public void AddScore(int newScore)
    {
        highScores.Add(newScore);
        highScores.Sort((a, b) => b.CompareTo(a));  // highest first

        if (highScores.Count > MaxScores)
        {
            highScores.RemoveRange(MaxScores, highScores.Count - MaxScores);
        }

        SaveScores();
    }

    public List<int> GetScores()
    {
        return new List<int>(highScores);
    }

    private void LoadScores()
    {
        highScores.Clear();
        for (int i = 0; i < MaxScores; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }
    }

    private void SaveScores()
    {
        for (int i = 0; i < MaxScores; i++)
        {
            int score = (i < highScores.Count) ? highScores[i] : 0;
            PlayerPrefs.SetInt("HighScore" + i, score);
        }

        PlayerPrefs.Save();
    }
}
