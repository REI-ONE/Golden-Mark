using Game.StateMachine.State;

namespace Game.StateMachine
{
    public interface IStateMachine
    {
        public IState Curent { get; }

        public void Switch(IState state);
        public void Monitoring();
        public void FixedMonitoring();
    }

    public abstract class BaseStateMachine : IStateMachine
    {
        public virtual IState Curent { get; private set; }

        public virtual void Monitoring()
        {
            Curent?.OnUpdate();
        }

        public virtual void FixedMonitoring()
        {
            Curent?.OnFixedUpdate();
        }

        public virtual void Switch(IState state)
        {
            Curent?.OnExit();
            Curent = state;
            Curent?.OnEnter();
        }
    }
}