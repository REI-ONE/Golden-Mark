using UnityEngine;
using System.Linq;
using Zenject;
using Fungus;

namespace Game.Installers
{
    public class SceneDialogInstaller : MonoInstaller
    {
        [field: SerializeField] public Flowchart[] Flowcharts { get; private set; }

        public override void InstallBindings() => Container.BindInstance(this);
        public Flowchart GetFlow(string name) => Flowcharts.FirstOrDefault(chart => chart.Equals(name));
    }
}