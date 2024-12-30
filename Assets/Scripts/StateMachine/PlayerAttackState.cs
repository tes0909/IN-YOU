using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAttackState : PlayerBaseState
{
    private bool isAttacking;
    
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isAttacking = true;
        stateMachine.Player.StartCoroutine(AttackTime());
    }

    public override void Exit()
    {
        base.Exit();
        isAttacking = false;
    }

    public override void Update()
    {
        base.Update();
        if (!isAttacking)
        {
            stateMachine.changeState(stateMachine.IdleState);
        }
    }

    private void OnAttack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(stateMachine.Player.transform.position,
            stateMachine.Player.PlayerSOData.AttackData.AttackRange);

        foreach (Collider2D enemy in hitEnemy)
        {
            // Bug bug = enemy.GetComponent<Bug>();
            // if (bug != null)
            // {
            //     bug.TakeDamage(stateMachine.Player.PlayerSOData.AttackData.AttackDamage);
            // }
        }
    }

    private IEnumerator AttackTime()
    {
        OnAttack();
        
        yield return new WaitForSeconds(stateMachine.Player.PlayerSOData.AttackData.AttackDuration);
        isAttacking = false;
        yield return new WaitForSeconds(stateMachine.Player.PlayerSOData.AttackData.AttackCooltime);
        
        stateMachine.changeState(stateMachine.IdleState);
    }
}
