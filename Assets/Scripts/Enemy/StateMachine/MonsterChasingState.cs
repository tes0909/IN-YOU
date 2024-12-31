using SuperTiled2Unity.Editor.LibTessDotNet;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier * 1.3f;
        base.Enter();
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

        LookAtPlayer();
        stateMachine.Monster.navAgent.SetDestination(stateMachine.Target.transform.position);

        if (!IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.WanderingState);
            return;
        }
        else if (IsInAttack())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return; 
        }
    }

    protected bool IsInAttack()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Monster.Stat.attractDistance * stateMachine.Monster.Stat.attractDistance;
    }
}
