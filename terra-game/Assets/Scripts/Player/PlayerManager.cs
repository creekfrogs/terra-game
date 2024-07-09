using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : CharacterManager
{
    [HideInInspector] public PlayerController playerController;
    [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
    protected override void Awake()
    {
        base.Awake();

        playerController = GetComponent<PlayerController>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();

        PlayerCamera.instance.player = this;
    }

    protected override void Update()
    {
        base.Update();

        playerController.HandleAllMovement();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        PlayerCamera.instance.HandleAllCameraActions();
    }
}
