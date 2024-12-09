public abstract class BugState
{
    protected Bug bug;

    public void SetBug(Bug bug)
    {
        this.bug = bug;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
