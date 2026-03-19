using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOverMulti : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    public static MenuGameOverMulti instance;
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
        isGameOverActive = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}