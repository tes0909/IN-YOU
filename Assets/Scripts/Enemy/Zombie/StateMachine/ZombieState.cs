using UnityEngine;
public abstract class ZombieState
{
    protected Zombie zombie;

    public void SetZombie(Zombie zombie)
    {
        this.zombie = zombie;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
