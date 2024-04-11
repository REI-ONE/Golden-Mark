using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class AimInstaller : MonoInstaller
    {
        [field: SerializeField] public Aim Aim { get; set; }

        public override void InstallBindings()
        {
            Container.BindInstance<Aim>(Aim);
        }
    }
}