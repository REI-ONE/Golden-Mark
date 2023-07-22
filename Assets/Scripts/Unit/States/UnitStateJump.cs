using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateJump : UnitStateWalk
    {
        public UnitStateJump(UnitDataBox data) : base(data)
        {
            StartAnimation = 3;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Rigidbody2D.AddForce(Vector2.up * DataBox.Data.Stats.JumpPower, ForceMode2D.Impulse);
        }

        public override void OnUpdate()
        {
        }
    }
}