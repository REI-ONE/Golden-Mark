using UnityEngine;
using System.Linq;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateWalk : UnitStateIdle
    {
        public Rigidbody2D Rigidbody2D { get; protected set; }
        public Vector2 Direction = Vector2.zero;

        public UnitStateWalk(UnitDataBox data) : base(data)
        {
            Rigidbody2D = DataBox.Data.Components.SingleOrDefault(comp => comp.GetType().Equals(typeof(Rigidbody2D))) as Rigidbody2D;
            StartAnimation = 1;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Move();
        }

        public virtual void Move()
        {
            Direction.y = Rigidbody2D.velocity.y;
            Direction.x = Input.GetAxis("Horizontal");
            Rigidbody2D.velocity = Direction * DataBox.Data.Stats.Speed;
        }
    }
}