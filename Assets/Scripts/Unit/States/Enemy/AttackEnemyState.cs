using Game.Weapons;
using UnityEngine;

namespace Game
{
    public abstract class BaseAttackEnemyState : UnitState
    {
        public BaseAttackEnemyState(IUnitController controller) : base(controller)
        {
        }

        public virtual void Attack(Transform target)
        {
            IWeapon weapon = null;

            if (Controller.Owner.Hand.Empty & (weapon = Controller.Owner.Hand.ItemHand as IWeapon) == null)
            {
                return;
            }

            if (!weapon.TryShot(target.transform.position) & weapon.Magazine.Empty)
            {
                weapon.Reloading();
            }
        }
    }
}