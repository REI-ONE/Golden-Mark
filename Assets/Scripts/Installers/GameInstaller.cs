using Game.Setting;
using UnityEngine;
using Game.Data;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Graphs _graphs;
    [SerializeField] private ViewDialoque _dialoque;
    [SerializeField] private GameSetting _setting;

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
        GameSetting game = _setting.Copy<GameSetting>();
        Container.BindInstance<IPause>(game.Pause);
    }
}