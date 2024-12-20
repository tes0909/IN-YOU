using Unity.VisualScripting;
using UnityEngine;

public class BugAttackingState : BugState
{
    private BugStats bugStats;
    private float attackCoolTime = 2.0f;
    private float lastAttackTime;
    public override void Enter()
    {
        bugStats = bug.bugStats;
        Debug.Log("버그 공격");
        lastAttackTime = 0;
    }

    public override void Update()
    {
        lastAttackTime += Time.deltaTime; // 경과시간누적
        if (lastAttackTime > attackCoolTime) // 쿨타임이 지났는지 확인
        {
            PlayerAttackDamage();
            lastAttackTime = 0; // 마지막 공격 시간 업데이트
            bug.ChangeState(bug.chasingState); 
            Debug.Log("플레이어 공격중");
        }
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
                float playerHealth = playerCondition.GetCurrentHealth();
                if (playerHealth > 0)
                {
                    playerCondition.TakeDamage(bugStats.attackPower);
                }
                else
                {
                    Debug.Log("플레이어 사망");
                }
            }
        }
    }
}
