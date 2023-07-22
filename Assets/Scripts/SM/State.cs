namespace Game.StateMachine.State
{
    public interface IState
    {
        public void OnEnter();
        public void OnExit();
        public void OnUpdate();
        public void OnFixedUpdate();
    }

    public abstract class BaseState : IState
    {
        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }
    }
}