using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; private set; }
    public Player Player { get; set; }

    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1.0f;

    public PlayerCondition Target { get; private set; }

    public MonsterWanderingState WanderingState { get; private set; }
    public MonsterAttackState AttackState { get; private set; }
    public MonsterChasingState ChasingState { get; private set; }

    public MonsterStateMachine(Monster monster)
    {
        this.Monster = monster;
        Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCondition>());
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCondition>();
        
        MovementSpeed = monster.Stat.moveSpeed;
        
        WanderingState = new MonsterWanderingState(this);
        AttackState = new MonsterAttackState(this);
        ChasingState = new MonsterChasingState(this);
    }
}