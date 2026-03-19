using System;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class BotAgent : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform deathZoneWaterLeft;
    [SerializeField] private Transform deathZoneWaterRight;
    
    private bool _isJumping;
    private const float JumpForce = 650f;
    private bool _isGrounded;
    
    private const float MaxRayCastDistance = 50f;
    private float _previousDistanceToTarget;
    private Vector2 _previousPosition; // Position précédente de l'agent
    private const float _movementThreshold = 1f; // Seuil de mouvement pour x et y
    
    public override void CollectObservations(VectorSensor sensor)
    {
        // Position relative de l'agent par rapport à la cible
        sensor.AddObservation(transform.position - target.position); // 2 observations (X, Y)

        // Distance entre l'agent et la cible
        sensor.AddObservation(Vector2.Distance(transform.position, target.position)); // 1 observation

        // État de saut et de contact avec le sol
        sensor.AddObservation(_isGrounded); // 1 observation

        // Raycasts simplifiés : détecter plateformes, ennemis, zones dangereuses
        Vector2[] directions = {
            Vector2.up, Vector2.right, Vector2.down, Vector2.left
        };

        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, MaxRayCastDistance);
            sensor.AddObservation(hit ? hit.distance : MaxRayCastDistance); // 1 observation par direction
        }

        // Total : 9 observations
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Actions
        float movement = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        float jump = Mathf.Clamp(actions.ContinuousActions[1], 0f, 1f);

        int attack = actions.DiscreteActions[0];

        float horizontalMovement = movement * PlayerMovement.instance.GetMoveSpeed() * Time.deltaTime;
        float verticalMovement = jump * PlayerMovement.instance.GetMoveSpeed() * Time.deltaTime;
        
        PlayerMovement.instance.MovePlayer(horizontalMovement, verticalMovement);

        // Saut
        _isGrounded = Physics2D.OverlapArea(
            PlayerMovement.instance.GroundCheckLeft.position,
            PlayerMovement.instance.GroundCheckRight.position
        );
        
        if (jump > 0 && _isGrounded) // Sauter
        {
            rb.AddForce(new Vector2(0f, PlayerMovement.instance.GetJumpForce()));
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
        
        if (attack > 0)
        {
            PlayerMovement.instance.Attack();
        }
        
        float currentDistanceToTarget = Vector2.Distance(transform.position, target.position);
        
        // Récompenser l'atteinte de la cible
        if (currentDistanceToTarget < 1f)
        {
            AddReward(1f);
            EndEpisode();
        }

        // Récompenser la réduction de la distance à la cible
        AddReward((_previousDistanceToTarget - currentDistanceToTarget) * 0.1f);

        if (IsAgentStuck())
        {
            AddReward(-1f); // Pénalité pour inactivité
            EndEpisode(); // Fin de l'épisode
        }

        _previousDistanceToTarget = currentDistanceToTarget;

        // Pénaliser les actions inutiles (saut ou attaque répétée sans but)
        if (!_isGrounded && jump > 0)
        {
            AddReward(-0.01f);
        }

        if (attack > 0 && PlayerMovement.instance.GetNextAttackTime() > Time.time)
        {
            AddReward(-0.05f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Actions
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Jump");
        
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = Input.GetButtonDown("Fire1") ? 1 : 0;
    }

    public override void OnEpisodeBegin()
    {
        AreaAttack.nextDamageTime = 0f; // Réinitialisation du temps entre les attaques
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            AddReward(-1f); // Pénalité pour avoir touché la zone de mort
            EndEpisode();
        }
    }

    private void Start()
    {
        Time.timeScale = 50f; // Accélérer l'entraînement
    }

    private bool IsAgentStuck()
    {
        // Vérifier si la différence de position dépasse le seuil
        Vector2 currentPosition = transform.position;
        float deltaX = Mathf.Abs(currentPosition.x - _previousPosition.x);
        float deltaY = Mathf.Abs(currentPosition.y - _previousPosition.y);

        // Mettre à jour la position précédente
        _previousPosition = currentPosition;

        // Retourner vrai si l'agent est immobile
        return deltaX < _movementThreshold && deltaY < _movementThreshold;
    }
}
