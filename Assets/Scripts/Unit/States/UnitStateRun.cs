using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateRun : UnitStateWalk
    {
        private float _multiplier = 0f;

        public UnitStateRun(UnitDataBox data) : base(data)
        {
            StartAnimation = 2;
            _multiplier = 2f;
        }

        public override void Move()
        {
            Direction.y = Rigidbody2D.velocity.y;
            Direction.x = Input.GetAxis("Horizontal") * DataBox.Data.Stats.Speed * _multiplier;
            Rigidbody2D.velocity = Direction;
        }
    }
}