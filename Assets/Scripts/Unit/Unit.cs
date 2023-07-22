using UnityEngine;
using Game.Data;

namespace Game.Gameplay.Units
{
    public interface IUnit
    {
        public IUnitController Controller { get; }
    }

    public abstract class Unit : MonoBehaviour, IUnit, IInitialization<UnitDataBox>
    {
        [field: SerializeField] public UnitDataBox DataBox { get; protected set; }
        public IUnitController Controller { get; protected set; }

        public virtual void Init(UnitDataBox data)
        {
            DataBox = data;
            DataBox.Data.Components = new();
        }
    }
}