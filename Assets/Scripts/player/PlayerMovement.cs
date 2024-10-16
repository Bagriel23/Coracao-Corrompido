using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    public Vector2 moveInput;
    public Vector3 movementDirection;
    private CharacterController characterController;
    public float movSpeed;
    private float verticalVelocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        controls = new PlayerControls();


        controls.PlayerInputs.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        controls.PlayerInputs.Movement.canceled += context => moveInput = Vector2.zero;

    }

    private void OnEnable()
    {
        controls.Enable();

    }

    private void OnDisable()
    {
        controls.Disable();
    }
    void Update()
    {
        ApplyMovement();
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
