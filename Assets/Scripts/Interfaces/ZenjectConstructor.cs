using UnityEngine;
using Zenject;

namespace Game
{
    public interface IZenjectConstructor
    {
        public DiContainer DiContainer { get; }

        public void Consturctor(DiContainer diContainer);
    }

    public abstract class ZenjectConstructor : IZenjectConstructor
    {
        public DiContainer DiContainer { get; private set; }

        public virtual void Consturctor(DiContainer diContainer)
        {
            DiContainer = diContainer;
        }
    }

    public abstract class MonoZenjectConstructor : MonoBehaviour, IZenjectConstructor
    {
        public DiContainer DiContainer { get; private set; }

        [Inject]
        public virtual void Consturctor(DiContainer diContainer)
        {
            DiContainer = diContainer;
        }
    }
}