using UnityEngine;

public class DeathZoneArenaTraining : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthArenaTraining.instance.takeDamage(PlayerHealthArenaTraining.instance.currentHealth);
        }
    }
}