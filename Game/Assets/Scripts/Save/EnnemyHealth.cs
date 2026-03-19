using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    // La santé maximale du joueur.
    public int maxHealth = 100;

    // La santé actuelle du joueur.
    public int currentHealth;

    // Instance statique de la classe PlayerHealth pour un accès global.
    public static EnnemyHealth instance;

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
    }

    // Méthode appelée à chaque frame.
    void Update()
    {
        // Vérifie si la touche "H" est pressée.
        // Si c'est le cas, le joueur subit des dégâts.
        if (Input.GetKeyDown(KeyCode.J))
        {
            takeDamage(10);
        }

        // Met à jour le paramètre "Health" de l'Animator (pour gérer les animations liées à la santé).
        animator.SetFloat("Health", currentHealth);
    }

    // Méthode pour infliger des dégâts au joueur.
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hit");
        Invoke("cutTree", 0.5f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void cutTree()
    {
        animator.SetBool("Hit", false);
    }

    void Die()
    {
        // Désactiver le Collider2D
        GetComponent<Collider2D>().enabled = false;

        MenuWin.instance.OnEnnemyDeath();
    }
}
