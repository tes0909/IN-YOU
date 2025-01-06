using System.Threading;
using TMPro;
using UnityEngine.AI;
using UnityEngine;

public class MonsterWanderingState : MonsterBaseState
{
    private float changeDirectionTime;
    private float timer;

    public MonsterWanderingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        timer = 0;
        base.Enter();
        SetRandomDestination();
        StartAnimation(stateMachine.Monster.AnimationData.WanderingParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.WanderingParameterHash);
    }

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            SetRandomDestination();
            LookForward();
            timer = 0f;
        }

        if (!stateMachine.Monster.NavAgent.pathPending && stateMachine.Monster.NavAgent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
            LookForward();
        }

        if (IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += stateMachine.Monster.NavAgent.transform.position; 

        Vector3 targetPosition;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
        {
            targetPosition = hit.position;
            stateMachine.Monster.NavAgent.SetDestination(targetPosition); 
            changeDirectionTime = Random.Range(1f, 3f); 
        }
    }

    private void LookForward()
    {
        Vector3 direction = stateMachine.Monster.NavAgent.velocity.normalized;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            stateMachine.Monster.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); 
        }
    }
}