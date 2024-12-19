using UnityEngine;

public class BirdAttackingState : BirdState
{
    public override void Enter()
    {
        Debug.Log("공격"); // Test
    }

    public override void Update()
    {
        // 플레이어 공격 로직?
        bird.ChangeState(bird.idleState); // 공격 > 대기
    }

    public override void Exit() { }
}
