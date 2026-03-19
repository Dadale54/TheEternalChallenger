using UnityEngine;

public class PlayerMoveMulti : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private float jumpForce = 650f;
    [SerializeField] private Transform attackZone;
    [SerializeField] private Vector2 attackOffsetLeft;
    [SerializeField] private Vector2 attackOffsetRight;
    [SerializeField] private float recoilForce = 1f;
    [SerializeField] private float attackCooldown = 0.5f;

    private float nextAttackTime = 0f;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping;
    public bool isGrounded;
    private bool canFlip = true;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public static PlayerMoveMulti instance;

    public float vitesseGrimpe = 5f;
    private bool surEchelle = false;

    private float lastSendTime = 0f;
    private float sendInterval = 0.05f;
    public bool sendMove = false;
    public HealthBarMultiPlayer healthBar;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladders"))
        {
            surEchelle = true;
            rb.gravityScale = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladders"))
        {
            surEchelle = false;
            rb.gravityScale = 2f;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        healthBar.setMaxHealth(100);
    }

    private void Update()
    {

        if (surEchelle)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * vitesseGrimpe * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * vitesseGrimpe * Time.deltaTime);
            }
            animator.SetBool("inLadder", true);
            return;
        }
        animator.SetBool("inLadder", false);

        isGrounded = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        Flip(rb.linearVelocity.x);
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        if (Time.time - lastSendTime >= sendInterval)
        {
            sendMove = true;
            Vector2 position = rb.position;
            SocketManager.instance.SendPlayerMovement(position.x, position.y, GetOrientation());
            lastSendTime = Time.time;
        }
        else
        {
            sendMove = false;
        }

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);
    }

    private int GetOrientation()
    {
        if (rb.linearVelocity.x > 0.5f)
            return 1; // Droite
        else if (rb.linearVelocity.x < -0.5f)
            return -1; // Gauche
        else if (surEchelle)
            return 2; // Ladder
        return 0; // Immobile
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);
    }

    void Flip(float _velocity)
    {
        if (canFlip)
        {
            if (_velocity > 0.5f)
            {
                spriteRenderer.flipX = false;
            }
            else if (_velocity < -0.5f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    void Attack()
    {
        if (Time.time > nextAttackTime)
        {
            attackZone.localPosition = spriteRenderer.flipX ? attackOffsetLeft : attackOffsetRight;

            SocketManager.instance.SendPlayerAttack("AttackLow", 0);

            attackZone.gameObject.SetActive(true);
            animator.SetTrigger("AttackLow");

            nextAttackTime = Time.time + attackCooldown;

            Invoke("DisableAttackZone", 0.5f);

            if (spriteRenderer.flipX)
            {
                rb.AddForce(Vector2.right * recoilForce);
            }
            else
            {
                rb.AddForce(Vector2.left * recoilForce);
            }

            canFlip = false;
            Invoke("EnableFlip", 0.2f);
        }
    }

    void EnableFlip()
    {
        canFlip = true;
    }

    void DisableAttackZone()
    {
        attackZone.gameObject.SetActive(false);
        animator.SetBool("AttackLow", false);
    }


}