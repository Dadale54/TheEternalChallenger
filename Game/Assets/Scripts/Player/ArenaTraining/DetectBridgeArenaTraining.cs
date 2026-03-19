using UnityEngine;

public class DetectBridgeArenaTraining : MonoBehaviour
{
    public GameObject bridgeCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bridge"))
        {
            GameObject bridge = collision.gameObject;

            bridgeCollider.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            bridgeCollider.SetActive(false);
        }
    }
}