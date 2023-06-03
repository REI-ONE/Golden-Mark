using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Graphs _graphs;
    [SerializeField] private ViewDialoque _dialoque;

    [System.Serializable]
    public class Graphs
    {
        [SerializeField] private Dialoque[] _dialoques;

        public void Bind(DiContainer container)
        {
            foreach (Dialoque dialoque in _dialoques)
                container.BindInstance<Dialoque>(dialoque).WithId(dialoque.name).AsCached();
        }
    }

    public override void InstallBindings()
    {
        Container.BindInstance<IViewDialoque>(_dialoque).AsSingle();
        _graphs.Bind(Container);
    }

    private void Start()
    {
        new PresentarDialoque(Container.ResolveId<Dialoque>("Welcome"), Container.Resolve<IViewDialoque>()).Execute();
    }
}