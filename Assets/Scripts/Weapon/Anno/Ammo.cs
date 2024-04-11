using UnityEngine;
using Game.Data;

namespace Game.HamdItems
{
    public interface IAmmo : IItemHand
    {
        public Vector3 Direction { get; }
        public bool Active { get; }
        public void SetDirection(Vector3 direction);
    }

    public abstract class Ammo : ItemHand, IAmmo
    {
        public Vector3 Direction { get; private set; }
        public bool Active { get; private set; } = false;

        private SOAmmo _SOAmmo;
        private float _timeLife;

        public override void Init(SOBaseItem data)
        {
            base.Init(data);
            _SOAmmo = data as SOAmmo;
            _timeLife = _SOAmmo.Model.Data._lifeTime;
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out Unit target))
            {
                IUnitDamageHit hit = null;
                if (target != Owner & (hit = target as IUnitDamageHit) != null)
                {
                    AttackData attack = new(Owner, _SOAmmo, _SOAmmo.Model.Data.Damage);
                    hit.Damage(attack);
                }
                Destroy(gameObject);
            }
        }

        public override void Execute()
        {
            base.Execute();
            Active = true;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Active)
            {
                // Вычисляем вектор движения, умножая направление на скорость и время кадра
                Vector3 movement = Direction.normalized * _SOAmmo.Model.Data.Speed * Time.deltaTime;

                // Перемещаем объект на вычисленное расстояние
                transform.Translate(movement);

                _timeLife -= Time.deltaTime;

                if (_timeLife <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}