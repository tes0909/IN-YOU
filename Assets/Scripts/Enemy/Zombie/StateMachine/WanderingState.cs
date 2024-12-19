using UnityEngine;

public class WanderingState : ZombieState
{
    private Vector2 targetPosition;  
    private float wanderTime = 0f;   // 목표 설정 시간 간격
    private float wanderCooldown = 2f; // 목표 변경 간격

    public override void Enter()
    {
        Debug.Log("이동 상태"); // Test
        SetNewTargetPosition();
    }

    public override void Update()
    {
        wanderTime += Time.deltaTime;

        if (wanderTime >= wanderCooldown) // 목표 갱신
        {
            wanderTime = 0f;
            SetNewTargetPosition();
        }

        MoveTowardsTarget(); // 목표 지점 이동

        if (Vector2.Distance(zombie.transform.position, zombie.player.position) <= zombie.zombieStats.aggroRange) // 일정 범위 내 > 추격 상태
        {
            zombie.ChangeState(zombie.chasingState);
        }
    }
    private void SetNewTargetPosition() // 목표 지점 설정
    {
        targetPosition = (Vector2)zombie.transform.position + Random.insideUnitCircle * 5f;
    }

    
    private void MoveTowardsTarget() // 목표 지점 이동
    {
        Vector2 direction = (targetPosition - (Vector2)zombie.transform.position).normalized;
        float step = zombie.zombieStats.moveSpeed * Time.deltaTime;
        zombie.transform.position = Vector2.MoveTowards(zombie.transform.position, targetPosition, step);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        zombie.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Z축 회전 고정
    }
    public override void Exit() { }
}
