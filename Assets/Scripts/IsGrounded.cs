using UnityEngine;
using System;

namespace Game
{
    public interface IIsGrounded
    {
        public LayerMask LayerMask { get; }
        public float Distance { get; }
        public Vector2 Direction { get; }
        public Color GizmosColor { get; }

        public bool CheckGround(Vector2 position);
    }

    [Serializable]
    public class IsGrounded : IIsGrounded
    {
        [field: SerializeField] public LayerMask LayerMask { get; private set; }
        [field: SerializeField] public float Distance { get; private set; } = 1f;
        [field: Header("(0,1) up, (0,-1) down, (-1,0) left, (1,0) right")]
        [field: SerializeField] public Vector2 Direction { get; private set; } = Vector2.down;
        [field: SerializeField] public Color GizmosColor { get; private set; } = Color.white;

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        public void SetDistance(float distance)
        {
            Distance = distance;
        }

        public virtual bool CheckGround(Vector2 position)
        {
            return Physics2D.Raycast(position, Direction, Distance, LayerMask);
        }
    }
}