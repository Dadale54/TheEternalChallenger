using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settingsWindow;

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("arenaAI");
    }

    public void StartTraining()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("arenaTraining");
    }

    public void StartMulti()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("arenaMulti");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}