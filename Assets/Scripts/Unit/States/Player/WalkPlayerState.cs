using UnityEngine;

namespace Game
{
    public class WalkPlayerState : BasePlayerState
    {
        public WalkPlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Walk);
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

            if (Input.GetKeyDown(KeyCode.S))
            {
                Machine.Switch(new SitdownPlayerState(Controller));
                return;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Machine.Switch(new RunPlayerState(Controller));
                return;
            }

            if (horizontal == .0f)
            {
                Machine.Switch(new IdlePlayerState(Controller));
                return;
            }
        }
    }
}