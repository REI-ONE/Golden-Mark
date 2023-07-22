using Game.StateMachine;
using Game.Data;

namespace Game.Gameplay.Units
{
    public interface IUnitController : IStateMachine, IInitialization<UnitDataBox>
    {
    }

    public abstract class UnitController : BaseStateMachine, IUnitController
    {
        public UnitDataBox DataBox { get; protected set; }

        public virtual void Init(UnitDataBox data)
        {
            DataBox = data;
        }
    }
}