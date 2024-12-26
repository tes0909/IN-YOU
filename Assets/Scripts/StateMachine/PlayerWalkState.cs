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
        sortingGroup = base.stateMachine.Player.GetComponent<SortingGroup>();
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.movementInput == Vector2.zero)
        {
            stateMachine.changeState(stateMachine.IdleState);
        }

        if (sortingGroup != null)
        {
            sortingGroup.sortingOrder = 
                (int)((stateMachine.Player.transform.position.y - sortingOrderOffest) * sortingOrderModifier);
        }
    }
}
