using Game.Weapons;
using UnityEngine;
using Game.Data;
using Zenject;

namespace Game.HamdItems
{
    public class PistolHand : Weapon
    {
        public Transform Target { get; protected set; }

        public override void Consturctor(DiContainer diContainer)
        {
            base.Consturctor(diContainer);
        }


        public override void Shot(SOAmmo ammo)
        {
            base.Shot(ammo);
            if (_ammos.Count > 0)
            {
                AmmoHandPistol ammoInList = _ammos[_ammos.Count - 1];
                if (!ammoInList.Active)
                {
                    ammoInList.SetDirection(Target.transform.position - transform.position);
                    ammoInList.Execute();
                }
            }
        }

        public virtual void LookAim()
        {
            transform.localRotation = LookTargte(Target.transform, 90f);
        }

        public virtual void ReloadPose()
        {
            transform.localRotation = Quaternion.Euler(0, 0, -45);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Magazine.CanUse)
            {
                LookAim();
                return;
            }

            ReloadPose();
        }
    }
}