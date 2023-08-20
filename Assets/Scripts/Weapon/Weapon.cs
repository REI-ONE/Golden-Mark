using System.Collections.Generic;
using Game.Interactables;
using UnityEngine;
using Game.Data;

namespace Game.Weapons
{
    public interface IWeapon
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

        public PistolBox Data { get; private set; }
        private PistolBox _runtimeData;

        private Transform _owner;
        private List<Bullet> _bullets;

        private void Awake()
        {
            _runtimeData = Data = Model.PistolBox;
            _owner = GetComponentInParent<Transform>();
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
                return true;
            }
            return false;
        }

        public void Reload()
        {
            _runtimeData = Data;
        }

        private void BulletCollider(Bullet bullet, IInterractable interractable)
        {
            bullet.Done -= BulletCollider;
            _bullets.Remove(bullet);
            Destroy(bullet.gameObject);
        }
    }
}