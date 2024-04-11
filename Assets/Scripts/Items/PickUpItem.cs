using UnityEngine.EventSystems;
using UnityEngine;
using Game.Data;

namespace Game.HamdItems
{
    public interface IPickUpItem : IInitialization<SOBaseItem>, IZenjectConstructor
    {
        public EventSystem EventSystem { get; }
        public SOBaseItem SOItem { get; }

        public void Up();
    }

    public abstract class PickUpItem : MonoZenjectConstructor, IPickUpItem
    {
        [SerializeField] public EventSystem EventSystem { get; private set; }
        [field: SerializeField] public SOBaseItem SOItem { get; private set; }

        public void Init(SOBaseItem data)
        {
            SOItem = data;
        }

        public virtual void Up()
        {
        }
    }
}