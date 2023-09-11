using Game.Gameplay.Units;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerUnit _player;

    public override void InstallBindings()
    {
        Container.BindInstance<PlayerUnit>(_player).AsSingle();
    }
}