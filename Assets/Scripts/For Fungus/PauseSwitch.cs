using Game.Installers;
using Zenject;

namespace Game
{
    public class PauseSwitch : MonoZenjectConstructor
    {
        public Pause Pause { get; private set; }

        public override void Consturctor(DiContainer diContainer)
        {
            base.Consturctor(diContainer);
            Pause = DiContainer.TryResolve<Pause>();
        }

        private void OnEnable()
        {
            Pause.Status = true;
        }

        private void OnDisable()
        {
            Pause.Status = false;
        }
    }
}