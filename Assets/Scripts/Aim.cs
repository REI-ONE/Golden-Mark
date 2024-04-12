using Fungus;
using Game.Installers;
using Game.Weapons;
using UnityEngine;

namespace Game
{
    public interface IAim : IInitialization<Unit>
    {
        public Color Free { get; }
        public Color InTarget { get; }
        public Unit Owner { get; }

        public void Move();
        public void LeftMouseButton();
        public void RightMouseButton();
    }

    public class Aim : MonoBehaviour, IAim
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public Color Free { get; private set; } = Color.white;
        [field: SerializeField] public Color InTarget { get; private set; } = Color.green;
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }

        public Unit Owner { get; private set; }
        public IWeapon Weapon { get; private set; }

        private bool _tryShot = false;
        private Pause _pause;
        public void Init(Unit data)
        {
            Owner = data;
            _pause = data.DiContainer.TryResolve<Pause>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out Unit unit))
            {
                if (unit != Owner)
                {
                    Renderer.color = InTarget;
                    _tryShot = true;
                }
            }

            if (collision.TryGetComponent<Clickable2D>(out Clickable2D clickable))
            {
                Renderer.enabled = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Renderer.color = Free;
            _tryShot = false;

            if (collision.TryGetComponent<Clickable2D>(out Clickable2D clickable))
            {
                Renderer.enabled = true;
            }
        }

        public void Move()
        {
            // Получаем текущие координаты курсора мыши в мировом пространстве
            Vector3 mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Убираем Z-координату, чтобы объект не двигался вглубь сцены
            // Перемещаем объект к координатам курсора мыши
            transform.position = mousePosition;
        }


        public void LeftMouseButton()
        {
            if (Owner != null && !Owner.Hand.Empty && (Weapon = Owner.Hand.ItemHand as Weapon) != null)
            {
                if (_tryShot)
                {
                    Weapon.TryShot(transform.position);
                }
            }

        }

        public void RightMouseButton()
        {
            if (Owner != null && !Owner.Hand.Empty && (Weapon = Owner.Hand.ItemHand as Weapon) != null)
            {
                Weapon.Reloading();
            }

        }

        private void Update()
        {
            if (_pause.Status)
            {
                return;
            }

            Move();

            if (Input.GetMouseButtonDown(0))
            {
                LeftMouseButton();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButton();
            }
        }
    }
}