using UnityEngine;

public class PlayerHealthArenaTraining : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    public static PlayerHealthArenaTraining instance;
    public Animator animator;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        animator.SetFloat("Health", currentHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        MenuGameOverArenaTraining.instance.OnPlayerDeath();
    }
}