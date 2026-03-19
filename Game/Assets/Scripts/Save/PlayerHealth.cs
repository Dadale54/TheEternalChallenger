using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // La santé maximale du joueur.
    public int maxHealth = 100;

    // La santé actuelle du joueur.
    public int currentHealth;

    // Référence à la barre de santé du joueur.
    public HealthBar healthBar;

    // Instance statique de la classe PlayerHealth pour un accès global.
    public static PlayerHealth instance;

    // Référence au composant Animator qui gère les animations du joueur.
    public Animator animator;

    // Méthode appelée avant le premier frame.
    public void Awake()
    {
        // Vérifie s'il existe déjà une instance de PlayerHealth.
        // S'il en existe une, cette instance est détruite pour éviter les doublons.
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Méthode appelée au début du jeu.
    public void Start()
    {
        // Initialise la santé actuelle à la santé maximale.
        currentHealth = maxHealth;

        // Initialise la barre de santé avec la santé maximale.
        healthBar.setMaxHealth(maxHealth);
    }

    // Méthode appelée à chaque frame.
    void Update()
    {
        // Vérifie si la touche "H" est pressée.
        // Si c'est le cas, le joueur subit des dégâts.
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(10);
        }

        // Met à jour le paramètre "Health" de l'Animator (pour gérer les animations liées à la santé).
        animator.SetFloat("Health", currentHealth);
    }

    // Méthode pour infliger des dégâts au joueur.
    public void takeDamage(int damage)
    {
        // Soustrait les dégâts à la santé actuelle.
        currentHealth -= damage;

        // Met à jour la barre de santé.
        healthBar.setHealth(currentHealth);

        // Vérifie si la santé du joueur est inférieure ou égale à zéro.
        // Si c'est le cas, le joueur meurt.
        if (currentHealth <= 0)
        {
            Invoke("Die", 1f);
            return;
        }
    }

    // Méthode appelée lorsque le joueur meurt.
    void Die()
    {
        // Met le jeu en pause.
        Time.timeScale = 0;

        // Appelle la méthode OnPlayerDeath du MenuGameOver.
        MenuGameOver.instance.OnPlayerDeath();
    }
}
