using UnityEngine;
using SocketIOClient;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using Newtonsoft.Json;
using SocketIOClient.Newtonsoft.Json;
using JetBrains.Annotations;

public class SocketManager : MonoBehaviour
{
    public static SocketManager instance;
    private SocketIOUnity socket;
    public Transform remotePlayer;
    public float remote_x = -100;
    public float remote_y = -100;
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float health = 100;
    public int orientation = 0;
    public string message;
    public int damage;
    public HealthBarMultiEnemy healthBar;
    [SerializeField] private GameObject loadUI;

    public Collider2D sword;
    public Collider2D remote;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        healthBar.setMaxHealth(100);
        var uri = new System.Uri("http://34.78.210.73:3000");
        socket = new SocketIOUnity(uri, new SocketIOOptions
        {
            Query = new Dictionary<string, string>
                {
                    {"token", "UNITY" }
                }
            ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });

        socket.JsonSerializer = new NewtonsoftJsonSerializer();

        socket.Connect();

        socket.On("player_moved", (reponse) => {
            loadUI.SetActive(false);
            var data = reponse.GetValue<PlayerMoveData>();
            remote_y = data.y;
            remote_x = data.x;
            orientation = data.orientation;
        });

        socket.On("player_attack", (reponse) => {
            var data = reponse.GetValue<PlayerAttackData>();
            message = data.message;
            damage = data.damage;
            PlayerHealthMulti.instance.takeDamage(damage);
        });
    }

    private void Update()
    {
        if (remotePlayer != null)
        {
            animator.SetBool("ladder", false);
            animator.SetFloat("health", health);
            remotePlayer.position = new Vector2(remote_x, remote_y);
            if (orientation == 0)
            {
                animator.SetFloat("speed", 0);
            }
            if (orientation == 1)
            {
                animator.SetFloat("speed", 1);
                spriteRenderer.flipX = false;
            }
            if (orientation == -1)
            {
                animator.SetFloat("speed", 1);
                spriteRenderer.flipX = true;
            }
            if (orientation == 2)
            {
                animator.SetBool("ladder", true);
            }

            if (sword.IsTouching(remote))
            {
                Debug.Log("Les colliders se touchent !");
                SendPlayerAttack("AttackLow", 5);
                health -= damage;
            }
            if(message == "AttackLow")
            {
                animator.SetBool("attack", true);
                Invoke("DisableAttack", 0.5f);
            }
        }
    }

    void DisableAttack()
    {
        message = "";
        damage = 0;
        animator.SetBool("attack", false);
    }


    public void SendPlayerMovement(float _x, float _y, int _orientation)
    {
        socket.Emit("player_move", JsonConvert.SerializeObject(new { x = _x, y = _y , orientation = _orientation}));
    }

    public void SendPlayerAttack(string _message, int _damage)
    {
        socket.Emit("player_attack", JsonConvert.SerializeObject(new { message = _message, damage = _damage }));
    }
}

// Classes pour la désérialisation JSON
[Serializable]
public class PlayerMoveData
{
    public string id;
    public float x;
    public float y;
    public int orientation;
}

[Serializable]
public class PlayerAttackData
{
    public string id;
    public string message;
    public int damage;
}