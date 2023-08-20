using UnityEngine;
using Game.Audio;
using Zenject;

namespace Game.Installers
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioController _audioController;

        public override void InstallBindings()
        {
            Container.BindInstance<IAudioController>(_audioController);
        }
    }
}