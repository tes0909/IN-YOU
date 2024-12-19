using UnityEngine;

public class ChasingState : ZombieState
{
    public override void Enter()
    {
        Debug.Log("추격 상태"); // Test
    }

    public override void Update()
    {
        Vector2 directionToPlayer = (zombie.player.position - zombie.transform.position).normalized; // 플레이어 추격
        zombie.transform.Translate(directionToPlayer * zombie.zombieStats.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(zombie.transform.position, zombie.player.position) <= zombie.zombieStats.attackRange) // 일정 거리 내 > 공격 상태
        {
            zombie.ChangeState(zombie.attackingState);
        }
        
        if (Vector2.Distance(zombie.transform.position, zombie.player.position) > zombie.zombieStats.aggroRange) // 추적 범위 밖 > Wandering 상태
        {
            zombie.ChangeState(zombie.wanderingState);
        }
    }

    public override void Exit() { }
}
