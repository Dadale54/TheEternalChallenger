using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Fonction appelée avant Start().
    private void Awake()
    {
        // Trouve le GameObject avec le tag "Player" dans la scène.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Définit la position du joueur à la position de ce GameObject (le point de spawn).
        player.transform.position = transform.position;
    }
}