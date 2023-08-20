using Game.Interactables;
using UnityEngine;
using System;

namespace Game.Weapons
{
    public interface IBullet : IInitialization<(Vector2 Direction, float Speed)>
    {
        public event Action<Bullet, IInterractable> Done;

        public void Move();
    }

    public class Bullet : MonoBehaviour, IBullet
    {
        public event Action<Bullet, IInterractable> Done;

        private Vector2 _direction;
        private float _speed;

        public void Init((Vector2 Direction, float Speed) data)
        {
            _direction = data.Direction;
            _speed = data.Speed;
        }

        public void Move() => transform.Translate(_direction * _speed * Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IInterractable>(out IInterractable interractable))
            {
                //Done?.Invoke(this, interractable);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IInterractable>(out IInterractable interractable))
            {
                switch (interractable)
                {
                    case Review review:
                        Done?.Invoke(this, interractable);
                        break;
                }
            }
        }
    }
}