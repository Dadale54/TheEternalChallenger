using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinMulti : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    public static MenuWinMulti instance;
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

    public void QuitGame()
    {
        Application.Quit();
    }
}