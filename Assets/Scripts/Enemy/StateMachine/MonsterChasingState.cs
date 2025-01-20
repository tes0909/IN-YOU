//using SuperTiled2Unity.Editor.LibTessDotNet;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MonsterChasingState : MonsterBaseState
{
    public MonsterChasingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1.3f;
        base.Enter();
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

        ChasePlayer();

        if (IsInAttack()&&IsInChasingRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
        else if(!IsInChasingRange()) 
        {
            stateMachine.ChangeState(stateMachine.WanderingState);
            return; 
        }
    }
}
