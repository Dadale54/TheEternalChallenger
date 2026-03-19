using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOverArenaTraining : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    public static MenuGameOverArenaTraining instance;
    public bool isGameOverActive = false;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
        isGameOverActive = true;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        isGameOverActive = false;
        SceneManager.LoadScene("Menu");
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        isGameOverActive = false;
        PlayerHealthArenaTraining.instance.Start();
        EnemyHealthTraining.instance.Start();
        SceneManager.LoadScene("arenaTraining");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}