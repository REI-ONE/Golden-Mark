using UnityEngine;

namespace Game
{
    public class JumpPlayerState : BasePlayerState
    {
        public JumpPlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Jump);
            Rigidbody.AddForce(Vector2.up * Controller.Owner.Stats.JumpPower);
        }

        public override void Update()
        {
            base.Update();
            float horizontal = Input.GetAxis("Horizontal");

            if (Controller.Owner.IsGrounded && horizontal == .0f)
            {
                Machine.Switch(new IdlePlayerState(Controller));
                return;
            }

            if (Controller.Owner.IsGrounded && horizontal != .0f)
            {
                Machine.Switch(new WalkPlayerState(Controller));
                return;
            }

            if (Controller.Owner.IsGrounded && Input.GetKey(KeyCode.LeftShift))
            {
                Machine.Switch(new RunPlayerState(Controller));
                return;
            }
        }
    }
}