using UnityEngine;

public class Bug : MonoBehaviour
{
    public BugStats bugStats;
    public Transform player;

    public BugState idleState;
    public BugState appearingState;
    public BugState chasingState;
    public BugState attackingState;

    private BugState currentState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        idleState = new BugIdleState();
        appearingState = new BugAppearingState();
        chasingState = new BugChasingState();
        attackingState = new BugAttackingState();

        idleState.SetBug(this);
        appearingState.SetBug(this);
        chasingState.SetBug(this);
        attackingState.SetBug(this);

        currentState = idleState;
    }

    private void Update()
    {
        currentState.Update();
    }

    public void ChangeState(BugState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
