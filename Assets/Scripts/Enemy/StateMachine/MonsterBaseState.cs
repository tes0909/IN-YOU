using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBaseState : IState
{
    public MonsterStateMachine stateMachine;

    public float changeDirectionTime;
    public float timer;

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

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;
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
            Vector3 direction = stateMachine.Target.transform.position - stateMachine.Monster.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            stateMachine.Monster.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public void SetRandomDestination()
    {
        Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x * 10f, 0, 0);
        Debug.Log(stateMachine.Monster.NavAgent.transform.position);
        Debug.Log(randomDirection);
        Debug.Log(stateMachine.Monster.transform.position);

        Vector3 targetPosition = stateMachine.Monster.NavAgent.transform.position + randomDirection;
        stateMachine.Monster.Renderer.flipX = randomDirection.x <= 0;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(targetPosition, out hit, 10f, NavMesh.AllAreas))
        {
            targetPosition = hit.position;
            stateMachine.Monster.NavAgent.SetDestination(targetPosition);
            changeDirectionTime = Random.Range(3f, 6f);
        }
    }
}