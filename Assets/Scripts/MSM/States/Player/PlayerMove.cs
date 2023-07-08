using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class PlayerMove : ContextState
    {
        private Stats _stats;
        private Rigidbody2D _rigidbody;
        private Vector3 _velocity;

        public PlayerMove(ContextStateMachine context, Rigidbody2D rigidbody, Stats stats) : base(context)
        {
            _rigidbody = rigidbody;
            _stats = stats;
        }

        public override void Enter()
        {
            _velocity.x = Input.GetAxis("Horizontal") * _stats.MovementSpeed;
            Move(_velocity);
        }

        public override void Exite()
        {
            _velocity.x = 0;
            Move(new Vector2(0, _velocity.y));
        }

        public override void Update()
        {
            if (Input.GetAxis("Horizontal") == 0)
                Context.FindToChange(typeof(PlayerIdle));
        }

        private void Move(Vector2 velocity)
        {
            velocity.y = _rigidbody.velocity.y;
            //            velocity = velocity.normalized;
            _rigidbody.velocity = velocity;
        }
    }
}