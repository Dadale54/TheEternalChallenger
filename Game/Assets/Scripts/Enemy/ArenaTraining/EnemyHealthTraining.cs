using UnityEngine;

public class EnemyHealthTraining : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    public HealthBarArenaTraining healthBar;
    public static EnemyHealthTraining instance;
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
        healthBar.setMaxHealth(maxHealth);
    }

    private void Update()
    {
        animator.SetFloat("Health", currentHealth);
        healthBar.setHealth(currentHealth);
    }

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
        GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 0;
        MenuWinArenaTraining.instance.OnEnnemyDeath();
    }
}
