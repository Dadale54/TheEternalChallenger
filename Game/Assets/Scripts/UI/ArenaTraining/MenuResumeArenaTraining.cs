using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuResumeArenaTraining : MonoBehaviour
{
    [SerializeField] private GameObject resumeUI;
    public static MenuResumeArenaTraining instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !MenuGameOverArenaTraining.instance.isGameOverActive && !MenuWinArenaTraining.instance.isWinActive)
        {
            OnResumePress();
        }
    }

    public void OnResumePress()
    {
        if (Time.timeScale == 1)
        {
            resumeUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            resumeUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}