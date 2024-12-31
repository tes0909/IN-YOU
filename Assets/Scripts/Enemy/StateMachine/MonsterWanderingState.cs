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
        StartAnimation(stateMachine.Monster.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        // 좌우 랜덤 이동로직
        if (timer >= changeDirectionTime)
        {
            SetRandomDestination();
            timer = 0f;
        }

        if (!stateMachine.Monster.navAgent.pathPending && stateMachine.Monster.navAgent.remainingDistance < 0.5f)
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
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += stateMachine.Monster.navAgent.transform.position; 

        Vector3 targetPosition;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
        {
            targetPosition = hit.position;
            stateMachine.Monster.navAgent.SetDestination(targetPosition); 
            changeDirectionTime = Random.Range(1f, 3f); 
        }
    }
}