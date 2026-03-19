using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinArenaTraining : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    public static MenuWinArenaTraining instance;
    public bool isWinActive = false;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void OnEnnemyDeath()
    {
        winUI.SetActive(true);
        isWinActive = true;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        isWinActive = false;
        SceneManager.LoadScene("Menu");
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        isWinActive = false;
        PlayerHealthArenaTraining.instance.Start();
        EnemyHealthTraining.instance.Start();
        SceneManager.LoadScene("arenaTraining");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}