using UnityEngine;

public class AttackingState : ZombieState
{
    public override void Enter()
    {
        Debug.Log("공격 상태"); // Test
    }

    public override void Update()
    {
        // Todo : 플레이어 공격 로직 (Player 데이터 생긴 후 추가 할 것) zombie.zombieStats.attackPower

        zombie.ChangeState(zombie.wanderingState); // 공격 후 다시 Wandering
    }

    public override void Exit() { }
}
