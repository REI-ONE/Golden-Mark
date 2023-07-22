using UnityEngine;

namespace Game.Extensions
{
    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public static class Vector
    {

        public static Direction ToDirection(this Vector2 _)
        {
            if (_ == Vector2.up)
                return Direction.Up;
            else if (_ == Vector2.down)
                return Direction.Down;
            else if (_ == Vector2.right)
                return Direction.Right;
            else if (_ == Vector2.left)
                return Direction.Left;

            return Direction.None;
        }

        public static Vector2 ToVector(this Direction _)
        {
            switch (_)
            {
                case Direction.Up:
                    return Vector2.up;
                case Direction.Down:
                    return Vector2.down;
                case Direction.Right:
                    return Vector2.right;
                case Direction.Left:
                    return Vector2.left;
            }

            return Vector2.zero;
        }
    }
}