using UnityEngine;

public class BugIdleState : BugState
{
    public override void Enter()
    {
        SpriteRenderer spriteRenderer = bug.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    public override void Update()
    {
        if (Vector2.Distance(bug.transform.position, bug.player.position) <= bug.bugStats.aggroRange)
        {
            bug.ChangeState(bug.appearingState);
        }
    }

    public override void Exit() { }
}
