using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    DetectInputs inputs;
    public Vector2 moveInput;
    public Vector3 movementDirection;
    private CharacterController characterController;
    public float movSpeed;
    private float verticalVelocity;
    Vector3 hitBoxPosition;
    public float attackRadius;
    float distanceInFront = 1.5f;
    [SerializeField] private bool attack;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputs = GetComponent<DetectInputs>();

    }
    private void Awake()
    {
        inputs = GetComponent<DetectInputs>();

        inputs.controls.PlayerInputs.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        inputs.controls.PlayerInputs.Movement.canceled += context => moveInput = Vector2.zero;
        inputs.controls.PlayerInputs.Attack.performed += context => attack = true;
        inputs.controls.PlayerInputs.Attack.canceled += context => attack = false;


    }
    void Update()
    {
        ApplyMovement();
        Attack();

    }

    private void ApplyMovement()
    {
        movementDirection = transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y));

        ApplyGravity();


        if (movementDirection.magnitude > 0)
        {
            characterController.Move(movementDirection * Time.deltaTime * movSpeed);
            
        }
        
    }

    private void Attack()
    {
        if (attack)
        {

            hitBoxPosition = this.transform.position + this.transform.forward * distanceInFront;

            Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] enemiesToDamage = Physics.OverlapBox(hitBoxPosition, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                EnemyLife enemyLife = enemiesToDamage[i].GetComponent<EnemyLife>();
                if (enemyLife != null)
                {
                    enemyLife.TakeDamage(1);
                }
            }
        }
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded == false)
        {
            verticalVelocity = verticalVelocity - 9.81f * Time.deltaTime;
            movementDirection.y = verticalVelocity;
        }
        else
        {
            verticalVelocity = -.5f;
        }
    }

    
}
