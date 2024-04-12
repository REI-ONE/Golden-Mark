using UnityEngine;
using Fungus;

namespace Game
{
    public class Clickable : MonoBehaviour
    {
        [field: SerializeField] public Sprite InHover { get; private set; }
        [field: SerializeField] public Flowchart Flowchart { get; private set; }
        [field: SerializeField] public string NameBlock { get; private set; }

        private Sprite _default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Aim>(out Aim aim))
            {
                _default = aim.Renderer.sprite;
                aim.Renderer.sprite = InHover;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Aim>(out Aim aim))
            {
                aim.Renderer.sprite = _default;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Aim>(out Aim aim))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Flowchart.ExecuteBlock(NameBlock);
                }
            }
        }
    }
}