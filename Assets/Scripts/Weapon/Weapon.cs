using System.Collections.Generic;
using Game.HamdItems;
using UnityEngine;
using Game.Data;

namespace Game.Weapons
{
    public interface IWeapon : IItemHand
    {
        public Magazine Magazine { get; }

        public Quaternion LookTargte(Transform target, float maxAngle);
        public bool TryShot();
        public void Shot(SOAmmo ammo);
        public void Reloading();
        public void Drop();
    }

    public abstract class Weapon : ItemHand, IWeapon
    {
        public Magazine Magazine { get; private set; }

        protected SOWeapon _SOWeapon;
        protected List<AmmoHandPistol> _ammos;
        private float _delay;

        public override void Init(SOBaseItem data)
        {
            base.Init(data);
            _SOWeapon = data as SOWeapon;
        }

        public override void SetOwner(Unit unit)
        {
            base.SetOwner(unit);
            Magazine = new Magazine();
            Magazine.Init(_SOWeapon.SOMagazine);
            _ammos = new List<AmmoHandPistol>((int)_SOWeapon.SOMagazine.Model.Data.Amount.Max);
        }

        public virtual bool TryShot()
        {
            if (_delay <= 0f)
            {
                SOAmmo ammo = Magazine.Get();

                if (ammo != null)
                {
                    Shot(ammo);
                    return true;
                }
            }

            return false;
        }

        public virtual void Shot(SOAmmo ammo)
        {
            AmmoHandPistol ammopistol = GameObject.Instantiate(ammo.PrefabHand) as AmmoHandPistol;
            ammopistol.transform.position = Owner.Hand.Anchor.position;
            ammopistol.Consturctor(DiContainer);
            ammopistol.SetOwner(Owner);
            ammopistol.Init(ammo);
            _ammos.Add(ammopistol);
            _delay = _SOWeapon.DelayBetweenShots;
        }

        public virtual void Reloading()
        {
            if (Magazine.CanUse)
            {
                Magazine.Reloading();
            }
        }

        public virtual void Drop()
        {
            ItemHand item = GameObject.Instantiate(_SOWeapon.PrefabHand);
            float offset = 3f;
            item.transform.position = Owner.transform.position + Owner.transform.localScale * offset;
            Destroy(Owner.Hand.ItemHand.gameObject);
        }

        //public override void Execute()
        //{
        //    base.Execute();
        //    if (!TryShot())
        //    {
        //        Reloading();
        //    }
        //}

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_delay > 0f)
            {
                _delay -= Time.deltaTime;
            }

            for (int index = _ammos.Count - 1; index >= 0; index--)
            {
                if (_ammos[index] != null)
                {
                    _ammos[index].OnUpdate();
                }
                else
                {
                    _ammos.RemoveAt(index);
                }
            }

            Magazine?.OnUpdate();
        }

        public virtual Quaternion LookTargte(Transform target, float maxAngle)
        {
            // Получаем локальное направление к целевому объекту от родительского объекта
            Vector3 localTargetDirection = transform.parent.InverseTransformDirection(target.position - transform.position);

            // Получаем угол между локальным направлением и осью X
            float angle = Mathf.Atan2(localTargetDirection.y, localTargetDirection.x) * Mathf.Rad2Deg;

            // Ограничиваем угол в пределах от -90 до 90 градусов
            angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

            // Поворачиваем подчиненный объект в соответствии с углом
            return Quaternion.Euler(0, 0, angle);
        }
    }
}