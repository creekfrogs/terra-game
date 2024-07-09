using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : CharacterManager
{
    PlayerController playerController;
    protected override void Awake()
    {
        base.Awake();

        playerController = GetComponent<PlayerController>();
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
