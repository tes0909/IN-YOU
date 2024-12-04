using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput { get; private set; }
    public PlayerInput.PlayerActions playerActions {get; private set;}
    void Start()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.Player; // 플레이어 레이어 접근
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
