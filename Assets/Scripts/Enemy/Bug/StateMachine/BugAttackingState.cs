using UnityEngine;

public class BugAttackingState : BugState
{
    public override void Enter()
    {
        Debug.Log("버그 공격");
    }

    public override void Update()
    {
        // 플레이어 공격 로직 추가할것
        bug.ChangeState(bug.chasingState); 
    }

    public override void Exit() { }
}
