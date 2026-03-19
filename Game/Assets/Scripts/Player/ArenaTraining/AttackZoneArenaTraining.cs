using UnityEngine;

public class AttackZoneArenaTraining : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float damageInterval = 0.5f;

    private float nextDamageTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            EnemyHealthTraining enemyHealth = other.GetComponent<EnemyHealthTraining>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(damage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}