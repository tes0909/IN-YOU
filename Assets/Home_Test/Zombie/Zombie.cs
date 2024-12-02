using UnityEngine;
public class Zombie : MonoBehaviour
{
    public ZombieStats zombieStats;
    public Transform player;
    
    public ZombieState wanderingState;
    public ZombieState chasingState;
    public ZombieState attackingState;

    private ZombieState currentState;

    private void Start()
    {
        wanderingState = new WanderingState();
        chasingState = new ChasingState();
        attackingState = new AttackingState();

        wanderingState.SetZombie(this);
        chasingState.SetZombie(this);
        attackingState.SetZombie(this);

        currentState = wanderingState; // 초기 상태 wandering

        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 추적
    }

    private void Update()
    {
        currentState.Update();
    }

    public void ChangeState(ZombieState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
