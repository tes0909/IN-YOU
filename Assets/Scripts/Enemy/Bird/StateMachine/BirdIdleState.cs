using UnityEngine;

public class BirdIdleState : BirdState
{
    public override void Enter()
    {
        Debug.Log("대기"); // Test
    }

    public override void Update()
    {
        if (Vector2.Distance(bird.transform.position, bird.player.position) <= bird.birdStats.aggroRange)
        {
            bird.ChangeState(bird.chasingState); // 일정 범위 내 플레이어 발견 > 추격 상태
        }
    }

    public override void Exit() { }
}