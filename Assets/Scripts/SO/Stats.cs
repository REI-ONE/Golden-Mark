using UnityEditor;
using UnityEngine;

namespace Game.Data
{
    public abstract class BaseMySO : ScriptableObject
    {
        public T Copy<T>() where T : ScriptableObject
        {
            T copy = ScriptableObject.CreateInstance<T>();
            EditorUtility.CopySerialized(this, copy);
            return copy;
        }
    }

    [CreateAssetMenu(menuName = "Game/Data/Stats")]
    public class Stats : BaseMySO
    {
        [field: SerializeField] public float MovementSpeed { get; set; } = 10f;
        [field: SerializeField] public float MovementSmoothing { get; set; } = 0f;
        [field: SerializeField] public float JumpForce { get; set; } = 400f;
        [field: SerializeField] public bool AirControl { get; set; } = true;
        [field: SerializeField] public float AirControlSmoothing { get; set; } = 0.5f;
        [field: SerializeField] public float DashForce { get; set; } = 25f;
        [field: SerializeField] public float DashTime { get; set; } = 0.5f;
        [field: SerializeField] public float DashCooldown { get; set; } = 3f;
        [field: SerializeField] public bool FacingRight { get; set; } = true;
        [field: SerializeField] public bool CanMove { get; set; } = true;
        [field: SerializeField] public bool Grounded { get; set; } = false;
        [field: SerializeField] public bool Jump { get; set; } = false;
        [field: SerializeField] public bool CanDoubleJump { get; set; } = false;
        [field: SerializeField] public bool CanDash { get; set; } = true;
        [field: SerializeField] public bool Dash { get; set; } = false;
        [field: SerializeField] public bool IsDashing { get; set; } = false;
        [field: SerializeField] public float LimitFallSpeed { get; set; } = 25f;

    }
}