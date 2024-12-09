using UnityEngine;

public class BugAppearingState : BugState
{
    public override void Enter()
    {
        SpriteRenderer spriteRenderer = bug.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        Debug.Log("버그 등장");
    }

    public override void Update()
    {
        bug.ChangeState(bug.chasingState);
    }

    public override void Exit() { }
}
