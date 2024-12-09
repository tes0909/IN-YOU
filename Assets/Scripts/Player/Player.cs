using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO PlayerSOData { get; private set; }
    
    [field:Header("Animation")] 
    [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    
    public Animator Animator { get; private set; }
    public PlayerController input { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }

    private PlayerStateMachine stateMachine;

    void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponent<Animator>();
        input = GetComponent<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        stateMachine = new PlayerStateMachine(this);
    }

    void Start()
    {
        stateMachine.changeState(stateMachine.IdleState);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        stateMachine.Update();
        stateMachine.HandleInput();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void RecoverHealth(int amount)
    {
        Debug.Log($"Health recovered by {amount}");
    }

    public void EquipItem(ItemData itemData)
    {
        Debug.Log($"Equipped {itemData.itemName}");
    }
}
