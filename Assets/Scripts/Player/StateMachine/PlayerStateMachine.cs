using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; set; }
    
    public Vector2 movementInput { get; set; }
    public float movementSpeed { get; private set; }
    //public float rotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    
    public PlayerIdleState IdleState { get; set; }
    public PlayerWalkState WalkState { get; set; }
    
    public PlayerAttackState AttackState { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        movementSpeed = player.PlayerSOData.GroundData.BaseSpeed;
        IdleState = new PlayerIdleState(this); // this statemachine
        WalkState = new PlayerWalkState(this);
        AttackState = new PlayerAttackState(this);
    }
}
