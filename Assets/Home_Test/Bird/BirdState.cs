public abstract class BirdState
{
    protected Bird bird;

    public void SetBird(Bird bird)
    {
        this.bird = bird;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}