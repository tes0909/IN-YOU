using System.Threading;
using TMPro;
using UnityEngine.AI;
using UnityEngine;

public class MonsterWanderingState : MonsterBaseState
{
   

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
}