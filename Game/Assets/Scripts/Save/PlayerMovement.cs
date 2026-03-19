using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // Vitesse de déplacement du joueur, ajustable pour contrôler la rapidité des mouvements horizontaux.
    private float moveSpeed = 300f;

    // Force du saut appliquée au joueur. Plus cette valeur est élevée, plus le saut est haut.
    private float jumpForce = 650f;

    private float lastSendTime = 0f;
    private float sendInterval = 0.05f;

    // Référence à la zone d'attaque
    public Transform attackZone;
    // Positions de la zone d'attaque à gauche et à droite
    public Vector2 attackOffsetLeft;
    public Vector2 attackOffsetRight;

    // Force de recul appliquée au joueur lors de l'attaque
    public float recoilForce = 1f;

    // Délai entre deux attaques
    public float attackCooldown = 0.5f;

    // Variable pour suivre le temps écoulé depuis la dernière attaque
    private float nextAttackTime = 0f;

    // Référence au composant Rigidbody2D pour appliquer la physique sur le joueur (mouvement, saut, gravité).
    public Rigidbody2D rb;

    // Vecteur utilisé pour gérer le lissage de la vélocité du joueur, rendant les mouvements plus fluides.
    private Vector3 velocity = Vector3.zero;

    // Indicateur de l'état du saut du joueur. Il est utilisé pour savoir si le joueur est en train de sauter.
    private bool isJumping;

    // Indicateur qui vérifie si le joueur est actuellement sur le sol.
    public bool isGrounded;

    // Références aux points de vérification pour détecter si le joueur touche le sol à gauche et à droite.
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;

    // Référence au composant Animator qui gère les animations du joueur.
    public Animator animator;

    public bool sendMove = false;

    // Référence au composant SpriteRenderer pour modifier l'apparence du joueur (par exemple, retournement du sprite).
    public SpriteRenderer spriteRenderer;

    // Instance statique permettant d'accéder à cette classe partout (Singleton pattern).
    public static PlayerMovement instance;

    private bool bridgesEnabled = true; // État des ponts

    // Pont
    public GameObject[] pont;
    public GameObject Bridge;


    // Fonction appelée avant Start(), utilisée pour initialiser l'instance unique de cette classe (Singleton).
    public void Awake()
    {
        // Si une instance de PlayerMovement existe déjà, on la conserve et on évite de recréer un objet supplémentaire.
        if (instance != null)
        {
            // Si l'instance existe, on détruit ce GameObject et on évite de continuer.
            return;
        }
        // Sinon, on définit cette instance comme l'instance unique.
        instance = this;
    }

    // Fonction Update() appelée à chaque frame. Elle gère les entrées du joueur et l'animation.
    private void Update()
    {
        // Désactive la physique du pont
        if (pont == null)
        {
            pont = GameObject.FindGameObjectsWithTag("Bridge");
        }

        // Vérifie si le joueur est au sol en utilisant OverlapArea avec les deux points de vérification.
        isGrounded = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);

        // Si l'utilisateur appuie sur le bouton de saut et que le joueur est au sol, on déclenche le saut.
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }
        // Gestion des ponts
        if (Input.GetKeyDown(KeyCode.DownArrow) || rb.linearVelocity.y > 1)
        {
            if (bridgesEnabled)
            {
                DisableBridges();
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || rb.linearVelocity.y < 1)
        {
            if (!bridgesEnabled)
            {
                EnableBridges();
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        // Appel à la fonction Flip pour retourner le sprite en fonction de la direction du mouvement.
        Flip(rb.linearVelocity.x);

        // Mise à jour du paramètre "Speed" dans l'animator pour que l'animation change selon la vitesse du joueur.
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }

    // Fonction FixedUpdate() appelée à intervalles réguliers, utilisée pour les calculs physiques (mouvement du joueur).
    void FixedUpdate()
    {
        // Si le joueur est en train de sauter, applique une force verticale pour effectuer le saut.
        if (isJumping == true)
        {
            // Applique la force de saut une seule fois
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        // Récupère l'input horizontal du joueur (clavier, manette, etc.) et le convertit en déplacement.
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Vérifier si le délai est écoulé avant d'envoyer la position
        if (Time.time - lastSendTime >= sendInterval)
        {
            sendMove = true;

            // Envoyer la position au serveur
            Vector2 position = rb.position;
            SocketManager.instance.SendPlayerMovement(position.x, position.y, GetOrientation());
            lastSendTime = Time.time;
        } else
        {
            sendMove = false;
        }

        MovePlayer(horizontalMovement, verticalMovement);
    }

    // Fonction qui gère le déplacement du joueur, appliquant une vélocité lissée et la gestion du saut.
    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (true)
        {
            // Crée un nouveau vecteur de vélocité cible, combinant le déplacement horizontal avec la vélocité verticale actuelle.
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);

            // Applique un lissage de la vélocité pour rendre le mouvement plus fluide et éviter des changements brusques.
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);
        }
    }

    // Fonction qui permet de retourner le sprite du joueur en fonction de la direction du mouvement horizontal.
    void Flip(float _velocity)
    {
        // Si la vitesse horizontale est positive (déplacement vers la droite), on affiche le sprite normalement.
        if (_velocity > 0.5f)
        {
            spriteRenderer.flipX = false;
        }
        // Si la vitesse horizontale est négative (déplacement vers la gauche), on retourne le sprite horizontalement.
        else if (_velocity < -0.5f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Attack()
    {

        // Mettre à jour la position de la zone d'attaque
        if (spriteRenderer.flipX)
        { // Si le sprite est retourné (orienté à gauche)
            attackZone.localPosition = attackOffsetLeft;
        }
        else
        { // Sinon (orienté à droite)
            attackZone.localPosition = attackOffsetRight;
        }

        // Appliquer la force de recul
        if (spriteRenderer.flipX)
        {
            // Recul vers la droite
            rb.AddForce(Vector2.right * recoilForce);
        }
        else
        {
            // Recul vers la gauche
            rb.AddForce(Vector2.left * recoilForce);
        }

        // Vérifier si le temps de recharge est écoulé
        if (Time.time > nextAttackTime)
        {
            // Envoyer l'attaque au serveur
            SocketManager.instance.SendPlayerAttack("AttackLow", 0);

            // Activer la zone d'attaque
            attackZone.gameObject.SetActive(true);

            // Déclencher l'animation d'attaque
            animator.SetTrigger("AttackLow");

            // Mettre à jour le temps de la prochaine attaque
            nextAttackTime = Time.time + attackCooldown;

            // Désactiver la zone d'attaque après un court délai (à ajuster selon l'animation)
            Invoke("DisableAttackZone", 0.5f);
        }
    }

    private int GetOrientation()
    {
        if (rb.linearVelocity.x > 0.5f)
            return 1; // Droite
        else if (rb.linearVelocity.x < -0.5f)
            return -1; // Gauche
        return 0; // Immobile
    }


    void DisableAttackZone()
    {
        attackZone.gameObject.SetActive(false);
        animator.SetBool("AttackLow", false);
    }

    private void DisableBridges()
    {
        foreach (GameObject pont in pont)
        {
            pont.GetComponent<PolygonCollider2D>().enabled = false;
        }
        bridgesEnabled = false; // Change l'état pour ne pas répéter l'action
    }

    private void EnableBridges()
    {
        foreach (GameObject pont in pont)
        {
            pont.GetComponent<PolygonCollider2D>().enabled = true;
        }
        bridgesEnabled = true; // Change l'état pour ne pas répéter l'action
    }
}