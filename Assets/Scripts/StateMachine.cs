public interface IState
{
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
    public void LateUpdate();
}

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public StateMachine(IState initState)
    {
        CurrentState = initState;
        CurrentState.Enter();
    }

    public void ChangeState(IState state)
    {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}