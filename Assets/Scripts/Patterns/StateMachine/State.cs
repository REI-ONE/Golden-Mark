namespace Game
{
    public interface IState
    {
        public StateMachine Machine { get; }

        public void Start();
        public void Finish();
        public void Update();
    }

    public abstract class State : IState
    {
        public virtual StateMachine Machine { get; protected set; }

        public virtual void Start() { }
        public virtual void Finish() { }
        public virtual void Update() { }
    }
}