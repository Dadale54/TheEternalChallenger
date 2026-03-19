using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    // Nom de la scène à charger lorsque le joueur appuie sur le bouton "Retry".
    public string levelToLoad;

    // Booléen pour suivre l'état du menu Game Over
    public bool isGameOverActive = false;

    // Référence au GameObject qui contient l'UI du Game Over.
    public GameObject gameOverUI;

    // Instance statique de la classe MenuGameOver pour un accès global.
    public static MenuGameOver instance;

    // Méthode appelée avant le premier frame.
    public void Awake()
    {
        // Vérifie s'il existe déjà une instance de MenuGameOver.
        // S'il en existe une, cette instance est détruite pour éviter les doublons.
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Méthode appelée lorsque le joueur meurt.
    public void OnPlayerDeath()
    {
        // Active l'UI du Game Over.
        gameOverUI.SetActive(true);
        isGameOverActive = true;
    }

    // Méthode appelée lorsque le joueur appuie sur le bouton "Menu".
    public void MainMenuButton()
    {
        // Charge la scène "Menu".
        SceneManager.LoadScene("Menu");
        isGameOverActive = false;
    }

    // Méthode appelée lorsque le joueur appuie sur le bouton "Retry".
    public void RetryButton()
    {
        // Charge la scène spécifiée par la variable levelToLoad.
        SceneManager.LoadScene(levelToLoad);

        Time.timeScale = 1;

        // Réinitialise la santé du joueur en appelant la méthode Start du script PlayerHealth.
        PlayerHealth.instance.Start();

        isGameOverActive = false;
    }

    // Fonction appelée lorsqu'on clique sur le bouton "Quitter".
    public void QuitGame()
    {
        // Quitte l'application.
        Application.Quit();
    }

}