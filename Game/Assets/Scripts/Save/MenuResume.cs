using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuResume : MonoBehaviour // Nom de la classe changé en MenuResume
{
    public static bool isPlaying = true;

    public GameObject resumeUI;

    public static MenuResume instance; // Type de l'instance changé en MenuResume

    public void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && MenuGameOver.instance.isGameOverActive == false)
        {
            {
                MenuResume.instance.OnResumePress(); // Appel de la méthode sur l'instance de MenuResume
            }
        }
    }

    public void OnResumePress()
    {
        if (isPlaying)
        {
            resumeUI.SetActive(true);
            isPlaying = false;
            Time.timeScale = 0;
        }
        else
        {
            resumeUI.SetActive(false);
            isPlaying = true;
            Time.timeScale = 1;
        }
    }
    public void ResumeButton()
    {
        resumeUI.SetActive(false);
        isPlaying = true;
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    // Fonction appelée lorsqu'on clique sur le bouton "Quitter".
    public void QuitGame()
    {
        // Quitte l'application.
        Application.Quit();
    }
}