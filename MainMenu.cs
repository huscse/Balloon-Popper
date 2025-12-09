using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [Header("Scene Names")]
[   SerializeField] private string firstLevelSceneName = "Level1";

    [Header("Main Menu Root")]
    [SerializeField] private GameObject mainMenuPanel;   // parent of Play/Instructions/Settings

    [Header("Panels")]
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject settingsPanel;

    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(firstLevelSceneName);

        // hide main menu once game starts
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
    }

    public void OpenInstructions()  => instructionsPanel.SetActive(true);
    public void CloseInstructions() => instructionsPanel.SetActive(false);

    public void OpenSettings()      => settingsPanel.SetActive(true);
    public void CloseSettings()     => settingsPanel.SetActive(false);

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHighScores()
    {
        SceneManager.LoadScene("HighScores");  // <-- Make sure this matches your scene name EXACTLY
    }

}
