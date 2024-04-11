namespace Game
{
    public interface IStateMachine : IUpdater
    {
        public IState Current { get; }

        public void Switch(IState state);
    }

    public abstract class StateMachine : IStateMachine
    {
        public IState Current { get; private set; }

        public virtual void Switch(IState state)
        {
            Current?.Finish();
            Current = state;
            state?.Start();
        }

        public virtual void OnUpdate()
        {
            Current?.Update();
        }
    }
}