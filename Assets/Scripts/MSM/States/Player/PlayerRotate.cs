using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class PlayerRotate : AsynchronousContextState
    {
        private Stats _stats;
        private Rigidbody2D _rigidbody;

        public PlayerRotate(ContextStateMachine context, Rigidbody2D rigidbody, Stats stats) : base(context)
        {
            _rigidbody = rigidbody;
            _stats = stats;
        }

        public override void Enter()
        {
        }

        public override void Exite()
        {
        }

        public override void Update()
        {
            if (Input.GetAxis("Horizontal") > 0 && !_stats.FacingRight)
                Flip();
            else if (Input.GetAxis("Horizontal") < 0 && _stats.FacingRight)
                Flip();
        }

        private void Flip()
        {
            _stats.FacingRight = !_stats.FacingRight;

            Vector3 theScale = _rigidbody.transform.localScale;
            theScale.x *= -1;
            _rigidbody.transform.localScale = theScale;

        }
    }
}