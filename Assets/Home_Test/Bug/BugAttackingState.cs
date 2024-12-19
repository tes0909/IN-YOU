using Unity.VisualScripting;
using UnityEngine;

public class BugAttackingState : BugState
{
    private BugStats bugStats;
    public override void Enter()
    {
        bugStats = bug.bugStats;
        Debug.Log("버그 공격");
    }

    public override void Update()
    {
        // 실행안됨
        PlayerAttackDamage();
        Debug.Log("플레이어 공격중");
        bug.ChangeState(bug.chasingState); 
    }

    public override void Exit() { }

    public void PlayerAttackDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(bug.transform.position, bugStats.attackRange);
        foreach (Collider2D player in hitPlayer)
        {
            PlayerCondition playerCondition = player.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                playerCondition.TakeDamage(bugStats.attackPower);
            }
        }
    }
}
