using Zenject;

namespace Game.HamdItems
{
    public class EnemyPistolHand : PistolHand
    {
        public override void Consturctor(DiContainer diContainer)
        {
            base.Consturctor(diContainer);
            Target = DiContainer.TryResolveId<Unit>("Player").gameObject.transform;
        }
    }
}