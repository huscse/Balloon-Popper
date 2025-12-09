using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public static bool IsPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
        IsPaused = false;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Resume()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void LoadMainMenu()
    {
        // 1️⃣ Save current score into high scores
        if (PersistentData.Instance != null && HighScoreManager.Instance != null)
        {
            int finalScore = PersistentData.Instance.currentScore;
            HighScoreManager.Instance.AddScore(finalScore);
        }

        // 2️⃣ Reset score for the next run (optional but nice)
        if (PersistentData.Instance != null)
        {
            PersistentData.Instance.ResetScore();
        }

        // 3️⃣ Go back to main menu as before
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
