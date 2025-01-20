using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    private PlayerCondition playerCondition;

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Monster.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInAttack())
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }
}