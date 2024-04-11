using Cinemachine;
using UnityEngine;
using Zenject;
using Game;

public class SpawnerInstaller : MonoInstaller
{
    [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; private set; }
    [field: SerializeField] public DistributorSpawnPositions DistributorSpawnPositions { get; private set; }
    [field: SerializeField] public Transform Contant { get; private set; }
    [field: SerializeField] public ModelSpawner Model { get; private set; }

    private ISpawner _spawner;

    public override void InstallBindings()
    {
        Container.BindInstance<CinemachineVirtualCamera>(VirtualCamera).AsSingle();
        _spawner = new Spawner(Contant);
        _spawner.Constructor(Container);
        _spawner.Init(Model);
        Container.BindInstance<ISpawner>(_spawner).AsSingle();
    }

    new private void Start()
    {
        StartCoroutine(_spawner.Spawn());
    }

    private void Update()
    {
        _spawner.OnUpdate();
    }
}