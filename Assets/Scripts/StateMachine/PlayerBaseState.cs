using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : Istate
{
    public PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        groundData = stateMachine.Player.PlayerSOData.GroundData;
    }
    public virtual void Enter()
    {
        AddInputActionsCallback();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallback();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void Update()
    {
        Move();
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    protected virtual void AddInputActionsCallback()
    {
        PlayerController input = stateMachine.Player.input;
        input.playerActions.Movement.canceled += OnMovementCanceld;
        //input.playerActions.Run.started += OnRunStarted;
    }
    
    protected virtual void RemoveInputActionsCallback()
    {
        PlayerController input = stateMachine.Player.input;
        input.playerActions.Movement.canceled -= OnMovementCanceld;
        //input.playerActions.Run.started -= OnRunStarted;
    }

    protected virtual void OnMovementCanceld(InputAction.CallbackContext context)
    {
        
    }
    
    protected virtual void OnRunStarted(InputAction.CallbackContext context)
    {
        
    }

    
    protected void StartAnimation(int animationHash) // 상태
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }
    
    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
    
    protected void SetDirectionAnimation(Vector2 direction) // 방향
    {
        stateMachine.Player.Animator.SetFloat(stateMachine.Player.AnimationData.MoveXParameterHash, direction.x);
        stateMachine.Player.Animator.SetFloat(stateMachine.Player.AnimationData.MoveYParameterHash, direction.y);
    }
    
    private void ReadMovementInput()
    {
        stateMachine.movementInput = stateMachine.Player.input.playerActions.Movement.ReadValue<Vector2>();
    }
    
    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        
        applyMovement(movementDirection); // 실제 캐릭터 컨트롤러를 사용하여 이동
        
        //Rotate(movementDirection); // 캐릭터가 바라보는 방향을 조정
    }

    private Vector2 GetMovementDirection()
    {
        return stateMachine.movementInput.normalized;
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = stateMachine.movementSpeed * stateMachine.MovementSpeedModifier;
        return moveSpeed;
    }
    
    private void applyMovement(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        if (direction != Vector3.zero) // 움직이면
        {
            SetDirectionAnimation(direction);
        }
        stateMachine.Player.rigidbody2D.velocity = direction * stateMachine.movementSpeed;
    }

    // private void Rotate(Vector3 direction)
    // {
    //     if (direction != Vector3.zero)
    //     {
    //         Transform playerTransform = stateMachine.Player.transform;
    //         Quaternion targetRotation = Quaternion.LookRotation(direction); // 바라보는 방향으로 
    //         
    //         //서서히 돌수있게끔 보간
    //         playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.rotationDamping * Time.deltaTime);
    //     }
    // }
}
