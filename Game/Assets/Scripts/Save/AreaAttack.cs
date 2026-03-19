using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    public int damage = 5; // Variable pour contrôler les dégâts
    public float damageInterval = 0.5f; // Intervalle entre les dégâts

    private float nextDamageTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy"))
        {
            if (Time.time >= nextDamageTime)
            {
                EnnemyHealth enemyHealth = other.GetComponent<EnnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.takeDamage(damage);
                    nextDamageTime = Time.time + damageInterval;
                }
            }
        }
    }
}