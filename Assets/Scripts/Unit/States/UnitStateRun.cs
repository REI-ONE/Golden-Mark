using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateRun : UnitStateWalk
    {
        private float _multiplayer = 0f;

        public UnitStateRun(UnitDataBox data) : base(data)
        {
            StartAnimation = 2;
            _multiplayer = 2f;
        }

        public override void Move()
        {
            Direction.y = Rigidbody2D.velocity.y;
            Direction.x = Input.GetAxis("Horizontal");
            Rigidbody2D.velocity = Direction * DataBox.Data.Stats.Speed * _multiplayer;
        }
    }
}