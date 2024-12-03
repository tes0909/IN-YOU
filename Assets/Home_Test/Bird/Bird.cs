using UnityEngine;

public class Bird : MonoBehaviour
{
    public BirdStats birdStats;
    public Transform player;

    public BirdState idleState;
    public BirdState chasingState;
    public BirdState attackingState;

    private BirdState currentState;

    private void Start()
    {
        idleState = new BirdIdleState();
        chasingState = new BirdChasingState();
        attackingState = new BirdAttackingState();

        idleState.SetBird(this);
        chasingState.SetBird(this);
        attackingState.SetBird(this);

        currentState = idleState;
    }

    private void Update()
    {
        currentState.Update();
    }

    public void ChangeState(BirdState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
