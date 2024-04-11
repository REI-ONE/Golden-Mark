using UnityEngine;

namespace Game
{
    public class SpawnPosition : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; } = "SpawnerPosition";
        [field: SerializeField] public Color Color { get; private set; } = Color.white;
        [field: SerializeField] public float Radius { get; private set; } = 1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}