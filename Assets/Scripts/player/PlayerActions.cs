using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    DetectInputs inputs;
    [Header("Inputs de movimento")]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector3 movementDirection;
    private CharacterController characterController;
    private bool dodge, dodgeIsActiveToUse;
    [SerializeField] private float timer;
    [Header("Config de Dodge ")]
    public float timerToDodge;
    public float distanceOfDodge;

    [Header("Config de movimento ")]
    public float movSpeed;
    private float verticalVelocity;

    [Header("Config de Range de ataque")]
    public float attackRadius;
    public Transform leftHitBoxPosition;
    public GameObject leftAttackVFX;
    public Transform rightHitBoxPosition;
    public GameObject rightAttackVFX;
    float distanceInFront = 1.5f;
    [SerializeField] private bool lAttack, rAttack;

    [Header("Config de dano de ataques")]
    public int leftMagicDamage;
    public float rightLowerSpeedIntensity;

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
        inputs.controls.PlayerInputs.Dodge.performed += context => dodge = true;
        inputs.controls.PlayerInputs.Dodge.canceled += context => dodge = false;
        inputs.controls.PlayerInputs.AttackRight.performed += context => rAttack = true;
        inputs.controls.PlayerInputs.AttackLeft.performed += context => lAttack = true;
        inputs.controls.PlayerInputs.AttackRight.canceled += context => rAttack = false;
        inputs.controls.PlayerInputs.AttackLeft.canceled += context => lAttack = false;


    }
    void Update()
    {
        ApplyMovement();
        ResetTimerToDodge();
        LeftAttack();
        RightAttack();
    }

  
    private void ApplyMovement()
    {
        movementDirection = transform.TransformDirection(new Vector3(moveInput.x, 0, moveInput.y));

        ApplyGravity();

        
        if (movementDirection.magnitude > 0)
        {


            characterController.Move(movementDirection * Time.deltaTime * movSpeed);

            if (dodge && dodgeIsActiveToUse)
            {
                characterController.Move(movementDirection * Time.deltaTime * distanceOfDodge);
                dodgeIsActiveToUse = false;
            }

        }

    }

    private void ResetTimerToDodge()
    {
        if (timer <= 0)
        {
            dodgeIsActiveToUse = true;
            timer = timerToDodge;
        }
        else if (!dodgeIsActiveToUse)
        {
            timer -= 1 * Time.deltaTime;
        }
    }

    private void LeftAttack()
    {

        //hitBoxPosition = this.transform.position + this.transform.forward * distanceInFront;
        if (lAttack)
        {
            /**Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] enemiesToDamage = Physics.OverlapBox(leftHitBoxPosition.position, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                EnemyLife enemyLife = enemiesToDamage[i].GetComponent<EnemyLife>();
                if (enemyLife != null)
                {
                    enemyLife.TakeDamage(leftMagicDamage);
                }
            }**/
            leftAttackVFX.SetActive(true);
        }
        else
        {
            leftAttackVFX.SetActive(false);
        }


    }

    private void RightAttack()
    {

        //hitBoxPosition = this.transform.position + this.transform.forward * distanceInFront;
        if (rAttack)
        {

            /**Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] enemiesToDamage = Physics.OverlapBox(rightHitBoxPosition.position, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                UnityEngine.AI.NavMeshAgent enemySpeed = enemiesToDamage[i].GetComponent<UnityEngine.AI.NavMeshAgent>();
                if (enemySpeed != null)
                {
                    enemySpeed.speed = rightLowerSpeedIntensity;
                }
            }**/
            rightAttackVFX.SetActive(true);
        }
        else
        {
            rightAttackVFX.SetActive(false);
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