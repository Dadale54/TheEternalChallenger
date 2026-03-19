using UnityEngine;

public class DeathZoneMulti : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealthMulti.instance.takeDamage(PlayerHealthMulti.instance.currentHealth);
        }
    }
}