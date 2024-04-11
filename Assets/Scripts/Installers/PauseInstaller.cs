using Zenject;

namespace Game.Installers
{
    public class Pause
    {
        public bool Status = false;
    }

    public class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Pause pause = ProjectContext.Instance.Container.TryResolve<Pause>();
            if (pause == null)
            {
                pause = new Pause();
                ProjectContext.Instance.Container.BindInstance<Pause>(pause).AsSingle();
            }

            Container.BindInstance<Pause>(pause).AsSingle();
        }
    }
}