using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    // Nom de la scène à charger lorsque le joueur appuie sur le bouton "Retry".
    public string levelToLoad;

    // Booléen pour suivre l'état du menu Win
    public bool isWinActive = false;

    // Référence au GameObject qui contient l'UI du Win.
    public GameObject winUI;

    // Instance statique de la classe MenuWin pour un accès global.
    public static MenuWin instance;

    // Méthode appelée avant le premier frame.
    public void Awake()
    {
        // Vérifie s'il existe déjà une instance de MenuWin.
        // S'il en existe une, cette instance est détruite pour éviter les doublons.
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Méthode appelée lorsque le joueur gagne.
    public void OnEnnemyDeath()
    {
        // Active l'UI du Game Over.
        winUI.SetActive(true);
        isWinActive = true;
    }

    // Méthode appelée lorsque le joueur appuie sur le bouton "Menu".
    public void MainMenuButton()
    {
        // Charge la scène "Menu".
        SceneManager.LoadScene("Menu");
        isWinActive = false;
    }

    // Méthode appelée lorsque le joueur appuie sur le bouton "Retry".
    public void RetryButton()
    {
        // Charge la scène spécifiée par la variable levelToLoad.
        SceneManager.LoadScene(levelToLoad);

        Time.timeScale = 1;

        // Réinitialise la santé du joueur en appelant la méthode Start du script PlayerHealth.
        EnnemyHealth.instance.Start();

        isWinActive = false;
    }

    // Fonction appelée lorsqu'on clique sur le bouton "Quitter".
    public void QuitGame()
    {
        // Quitte l'application.
        Application.Quit();
    }

}