using UnityEngine;
using Zenject;

public class PauseObject
{
    public bool Active => !_self.gameObject.activeSelf;
    private Transform _self;
    public PauseObject(Transform transform) => _self = transform;
    public void Set(bool active) => _self.gameObject.SetActive(!active);
}

public class PauseGameObjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance<PauseObject>(new PauseObject(transform));
    }
}