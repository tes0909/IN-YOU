using UnityEngine;

public class BirdChasingState : BirdState
{
    public override void Enter()
    {
        Debug.Log("추격"); // Test
    }

    public override void Update()
    {
        Vector2 directionToPlayer = (bird.player.position - bird.transform.position).normalized;
        bird.transform.Translate(directionToPlayer * bird.birdStats.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(bird.transform.position, bird.player.position) <= bird.birdStats.attackRange)
        {
            bird.ChangeState(bird.attackingState); // 공격 범위 내 도달 > 공격 상태
        }
    }

    public override void Exit() { }
}
