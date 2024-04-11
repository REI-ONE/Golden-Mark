using Game.Installers;

namespace Game
{
    public interface IUnitController : IStateMachine, IInitialization<Unit>
    {
        public Pause Pause { get; }
        public Unit Owner { get; }

        public void Rotate();
    }

    public abstract class UnitController : StateMachine, IUnitController
    {
        public Unit Owner { get; private set; }
        public Pause Pause { get; private set; }

        public virtual void Init(Unit data)
        {
            Owner = data;
            Pause = data.DiContainer.TryResolve<Pause>();
        }

        public virtual void Rotate()
        {
        }

        public override void OnUpdate()
        {
            if (Pause.Status)
                return;

            base.OnUpdate();
        }
    }
}