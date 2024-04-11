using UnityEngine;

namespace Game
{
    public class IdlePlayerState : BasePlayerState
    {
        private float _deadArea = .2f;

        public IdlePlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Idle);
        }

        public override void Update()
        {
            base.Update();
            float horizontal = Input.GetAxis("Horizontal");

            if (Controller.Owner.IsDead)
            {
                Machine.Switch(new DeadPlayerState(Controller));
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && Controller.Owner.IsGrounded)
            {
                Machine.Switch(new JumpPlayerState(Controller));
                return;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Machine.Switch(new SitdownPlayerState(Controller));
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Machine.Switch(new RunPlayerState(Controller));
                return;
            }

            if (horizontal != .0f && (horizontal < -_deadArea || horizontal > _deadArea))
            {
                Machine.Switch(new WalkPlayerState(Controller));
                return;
            }
        }
    }
}