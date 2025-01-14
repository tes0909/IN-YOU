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
        stateMachine.MovementSpeedModifier = 1f;
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
            timer = 0f;
        }

        if (!stateMachine.Monster.NavAgent.pathPending && stateMachine.Monster.NavAgent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }

        if (IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }

    private void SetRandomDestination()
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