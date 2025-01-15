using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerWalkState : PlayerBaseState
{
    private readonly SortingGroup sortingGroup;
    private readonly int sortingOrderModifier = -10;
    private readonly float sortingOrderOffest = 0.5f;
    public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        sortingGroup = base.StateMachine.Player.GetComponent<SortingGroup>();
    }

    public override void Enter()
    {
        StateMachine.MovementSpeedModifier = 1f;
        base.Enter();
        StartAnimation(StateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(StateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (StateMachine.movementInput == Vector2.zero)
        {
            StateMachine.ChangeState(StateMachine.IdleState);
        }

        if (sortingGroup != null)
        {
            sortingGroup.sortingOrder = 
                (int)((StateMachine.Player.transform.position.y - sortingOrderOffest) * sortingOrderModifier);
        }
    }
}
