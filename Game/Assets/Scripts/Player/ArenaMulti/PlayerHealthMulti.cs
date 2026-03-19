using UnityEngine;

public class PlayerHealthMulti : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    public static PlayerHealthMulti instance;
    public Animator animator;
    public HealthBarMultiPlayer healthBar;

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
        healthBar.setHealthPlayer(currentHealth);
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
        MenuGameOverMulti.instance.OnPlayerDeath();
    }
}