using UnityEngine;

public class AttackZoneMulti : MonoBehaviour
{
    [SerializeField] private float damageInterval = 0.5f;

    private float nextDamageTime = 0f;
    public HealthBarMultiEnemy healthBar;
    public Animator animator;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RemotePlayer") && Time.time >= nextDamageTime)
        {
            nextDamageTime = Time.time + damageInterval;
            SocketManager.instance.SendPlayerAttack("AttackLow", 5);
            SocketManager.instance.health -= 5;
            animator.SetFloat("health", SocketManager.instance.health);
            healthBar.setHealthEnemy(SocketManager.instance.health);
        }
    }
}