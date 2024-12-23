using UnityEngine;

public class BugChasingState : BugState
{
    public override void Enter()
    {
        Debug.Log("추격 시작");
    }

    public override void Update()
    {
        Vector2 directionToPlayer = (bug.player.position - bug.transform.position).normalized;
        bug.transform.Translate(directionToPlayer * bug.bugStats.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(bug.transform.position, bug.player.position) <= bug.bugStats.attackRange)
        {
            bug.ChangeState(bug.attackingState); // 범위 내 > 공격
        }
    }

    public override void Exit() { }
}
