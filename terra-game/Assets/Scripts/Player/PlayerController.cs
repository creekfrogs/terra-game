using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    PlayerManager playerManager;
    public Rigidbody rb;

    [Header("Locomotion")]
    private float verticalMovement;
    private float horizontalMovement;
    private float moveAmount;
    private Vector3 moveDirection;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed;

    [Header("Speeds")]
    [SerializeField] float walkingSpeed = 2;
    [SerializeField] float runningSpeed = 5;

    protected override void Awake()
    {
        base.Awake();

        playerManager = GetComponent<PlayerManager>();
    }
    public void HandleAllMovement()
    {
        HandleGroundedMovement();

        HandleRotation();
    }

    private void GetAllInputs()
    {
        verticalMovement = PlayerInputManager.instance.verticalInput;
        horizontalMovement = PlayerInputManager.instance.horizontalInput;

        //CLAMP THESE
    }

    private void HandleGroundedMovement()
    {
        GetAllInputs();

        moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
        moveDirection += PlayerCamera.instance.transform.right * horizontalMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerInputManager.instance.moveAmount > 0.5f)
        {
            rb.AddForce(moveDirection * runningSpeed, ForceMode.VelocityChange);
        }
        else if (PlayerInputManager.instance.moveAmount <= 0.5f)
        {
            rb.AddForce(moveDirection * walkingSpeed, ForceMode.VelocityChange);
        }
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = PlayerCamera.instance.cameraObject.transform.forward * verticalMovement;
        targetDirection += PlayerCamera.instance.cameraObject.transform.right * horizontalMovement;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
