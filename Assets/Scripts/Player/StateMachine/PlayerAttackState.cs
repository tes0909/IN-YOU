using System.Collections;
using UnityEngine;

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
        StateMachine.Player.input.playerActions.Disable();
        StateMachine.Player.StartCoroutine(AttackTime());
    }

    public override void Exit()
    {
        base.Exit();
        StateMachine.Player.input.playerActions.Enable();
        isAttacking = false;
    }

    public override void Update()
    {
        base.Update();
        if (!isAttacking)
        {
            StateMachine.ChangeState(StateMachine.IdleState);
        }
    }

    private void OnAttack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(StateMachine.Player.transform.position,
            StateMachine.Player.PlayerSOData.AttackData.AttackRange);

        foreach (Collider2D enemy in hitEnemy)
        {
            //Bug bug = enemy.GetComponent<Bug>();
            //if (bug != null)
            //{
            //    bug.TakeDamage(stateMachine.Player.PlayerSOData.AttackData.AttackDamage);
            //}
        }
    }

    private IEnumerator AttackTime()
    {
        OnAttack();
        
        yield return new WaitForSeconds(StateMachine.Player.PlayerSOData.AttackData.AttackDuration);
        isAttacking = false;
        yield return new WaitForSeconds(StateMachine.Player.PlayerSOData.AttackData.AttackCooltime);
        if (!isAttacking)
        {
            StateMachine.ChangeState(StateMachine.IdleState);
        }
    }
}
