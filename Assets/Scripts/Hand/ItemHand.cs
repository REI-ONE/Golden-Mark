using UnityEngine;
using Game.Data;
using Zenject;

namespace Game
{
    public interface IItemHand : IInitialization<SOBaseItem>, ICommand, IUpdater, IZenjectConstructor
    {
        public Unit Owner { get; }
        public SOBaseItem SOItem { get; }

        public void SetOwner(Unit unit);
    }

    public abstract class ItemHand : MonoInitialization, IItemHand
    {
        [field: SerializeField] public SOBaseItem SOItem { get; private set; }
        [field: SerializeField] public Unit Owner { get; private set; }
        [field: SerializeField] public DiContainer DiContainer { get; private set; }

        public virtual void Consturctor(DiContainer diContainer)
        {
            DiContainer = diContainer;
        }

        public virtual void Init(SOBaseItem data)
        {
            SOItem = data;
        }

        public virtual void SetOwner(Unit unit)
        {
            Owner = unit;
            Consturctor(unit.DiContainer);
        }

        public virtual void Execute()
        {
        }

        public virtual void Endo()
        {
        }

        public virtual void OnUpdate()
        {
        }
    }
}