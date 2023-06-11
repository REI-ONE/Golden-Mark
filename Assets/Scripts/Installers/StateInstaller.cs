using UnityEngine;
using Zenject;

public class StateInstaller : MonoInstaller
{
    [SerializeField] SO.MoveState _moveState;
    public override void InstallBindings()
    {
        Container.BindInstance(_moveState).AsSingle();
    }
}