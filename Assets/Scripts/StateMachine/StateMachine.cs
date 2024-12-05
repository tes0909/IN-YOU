using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate
{
    public void Enter();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void PhysicsUpdate();
}

public abstract class StateMachine
{
    protected Istate currentState;

    public void changeState(Istate State)
    {
        currentState?.Exit();
        currentState = State;
        currentState?.Enter();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
