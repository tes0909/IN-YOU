using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    public PlayerStateMachine StateMachine;
    protected readonly PlayerGroundData GroundData;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.StateMachine = stateMachine;
        GroundData = stateMachine.Player.PlayerSOData.GroundData;
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
        PlayerController input = StateMachine.Player.input;
        input.playerActions.Movement.performed += OnMovementCanceld;
        input.playerActions.Attack.performed += OnAttackPerformed;
        input.playerActions.PickUp.performed += OnPickUpPerformed;
        input.playerActions.ESC.started += OnEscStarted;
    }



    protected virtual void RemoveInputActionsCallback()
    {
        PlayerController input = StateMachine.Player.input;
        input.playerActions.Movement.canceled -= OnMovementCanceld;
        input.playerActions.Attack.canceled -= OnAttackCanceld;
        input.playerActions.PickUp.canceled -= OnPickUpCanceld;
        input.playerActions.ESC.canceled -= OnEscCanceld;
    }
    private void OnEscStarted(InputAction.CallbackContext context)
    {
        Managers.UI.EscPopupInput();
    }

    private void OnEscCanceld(InputAction.CallbackContext context)
    {
        
    }

    private void OnPickUpPerformed(InputAction.CallbackContext context)
    {
        StateMachine.Player.PickUpItem();
    }
    private void OnPickUpCanceld(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnMovementCanceld(InputAction.CallbackContext context)
    {
        
    }
    

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        StateMachine.Player.Animator.SetTrigger(StateMachine.Player.AnimationData.AttackParameterHash);
        StateMachine.ChangeState(StateMachine.AttackState);
    }

    private void OnAttackCanceld(InputAction.CallbackContext context)
    {
        
    }
    
    protected void StartAnimation(int animationHash) // 상태
    {
        StateMachine.Player.Animator.SetBool(animationHash, true);
    }
    
    protected void StopAnimation(int animationHash)
    {
        StateMachine.Player.Animator.SetBool(animationHash, false);
    }
    
    protected void SetDirectionAnimation(Vector2 direction) // 방향
    {
        StateMachine.Player.Animator.SetFloat(StateMachine.Player.AnimationData.MoveXParameterHash, direction.x);
        StateMachine.Player.Animator.SetFloat(StateMachine.Player.AnimationData.MoveYParameterHash, direction.y);
    }
    
    private void ReadMovementInput()
    {
        StateMachine.movementInput = StateMachine.Player.input.playerActions.Movement.ReadValue<Vector2>();
    }
    
    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();
        
        ApplyMovement(movementDirection);
    }

    private Vector2 GetMovementDirection()
    {
        return StateMachine.movementInput.normalized;
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = StateMachine.movementSpeed * StateMachine.MovementSpeedModifier;
        return moveSpeed;
    }
    
    private void ApplyMovement(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        if (direction != Vector3.zero) // 움직이면
        {
            SetDirectionAnimation(direction);
        }
        StateMachine.Player.rigidbody2D.velocity = direction * StateMachine.movementSpeed;
    }
}
