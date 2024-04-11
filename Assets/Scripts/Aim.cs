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

        public void Init(Unit data)
        {
            Owner = data;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Unit>(out Unit unit))
            {
                Renderer.color = InTarget;
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Renderer.color = Free;
        }

        public void Move()
        {
            // �������� ������� ���������� ������� ���� � ������� ������������
            Vector3 mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // ������� Z-����������, ����� ������ �� �������� ������ �����
            // ���������� ������ � ����������� ������� ����
            transform.position = mousePosition;
        }


        public void LeftMouseButton()
        {
            if (Owner != null && !Owner.Hand.Empty && (Weapon = Owner.Hand.ItemHand as Weapon) != null)
            {
                Weapon.TryShot();
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