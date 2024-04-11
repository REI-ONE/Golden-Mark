using Zenject;

namespace Game.HamdItems
{
    public class PlayerPistolHand : PistolHand
    {
        public override void Consturctor(DiContainer diContainer)
        {
            base.Consturctor(diContainer);
            Target = DiContainer.TryResolve<Aim>().gameObject.transform;
        }
    }
}