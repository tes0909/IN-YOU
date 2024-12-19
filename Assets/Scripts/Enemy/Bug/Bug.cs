using Unity.VisualScripting;
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

        if (bugStats != null)
        {
            bugStats.currentHealth = bugStats.maxHealth;
        }

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

    public void TakeDamage(float damage)
    {
        bugStats.currentHealth -= damage;
        Debug.Log($"{bugStats.name}가 {damage}의 데미지를 받았습니다. 현재 체력: {bugStats.currentHealth}");

        if (bugStats.currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("사망");
        }
    }
}
