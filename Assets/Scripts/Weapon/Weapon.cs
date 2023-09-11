using System.Collections.Generic;
using Game.Interactables;
using UnityEngine;
using Game.Data;
using System;

namespace Game.Weapons
{
    public interface IWeaponCallback
    {
        public event Action<int> Executed;
    }

    public interface IWeapon : IWeaponCallback
    {
        public PistolBox Data { get; }

        public bool Fire();
        public void Reload();
    }

    public class Weapon : MonoBehaviour, IWeapon
    {
        [field: SerializeField] public PistolModel Model { get; private set; }
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _parentBullet;

        public int BulletAmmount => _runtimeData.Amount;
        public PistolBox Data { get; private set; }
        private PistolBox _runtimeData;

        private Transform _owner;
        private List<Bullet> _bullets;

        public event Action<int> Executed;

        private void Awake()
        {
            _runtimeData = Data = Model.PistolBox;
            _owner = transform.parent;
            _bullets = new List<Bullet>(Data.MaxAmount);
        }

        private void Update()
        {
            if (_bullets != null && _bullets.Count > 0)
                for (int i = _bullets.Count - 1; i > -1; i--)
                    _bullets[i].Move();
        }

        public bool Fire()
        {
            if (_runtimeData.Amount > 0)
            {
                Bullet bullet = Instantiate(_prefab, _parentBullet);
                bullet.transform.position = transform.position;
                bullet.Init((_owner.localScale.x == 1 ? Vector2.right : Vector2.left, Data.Speed));
                bullet.Done += BulletCollider;
                bullet.gameObject.SetActive(true);
                _bullets.Add(bullet);
                _runtimeData.Amount -= 1;
                Executed?.Invoke(_runtimeData.Amount);
                return true;
            }
            return false;
        }

        public void Reload()
        {
            _runtimeData = Data;
            Executed?.Invoke(_runtimeData.Amount);
        }

        private void BulletCollider(Bullet bullet, IInterractable interractable)
        {
            bullet.Done -= BulletCollider;
            _bullets.Remove(bullet);
            Destroy(bullet.gameObject);
        }
    }
}