using Unity.VisualScripting;
using UnityEngine;

public class MonsterBaseState : IState
{
    public MonsterStateMachine stateMachine;

    protected MonsterBaseState(MonsterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        GetMovementSpeed();
    }

    protected void StartAnimation(int animationHash) 
    {
        stateMachine.Monster.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Monster.Animator.SetBool(animationHash, false);
    }

    protected bool IsInChasingRange()
    {
        if (stateMachine.Target.IsDie)
        {
            return false;
        }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.NavAgent.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Monster.Stat.attractDistance * stateMachine.Monster.Stat.attractDistance;
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    public void LookAtPlayer()
    {
        if (stateMachine.Target != null)
        {
            Vector3 direction = stateMachine.Target.transform.position - stateMachine.Monster.NavAgent.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            stateMachine.Monster.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}