using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public int currentScore = 0;
    public int difficulty = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // survives scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
