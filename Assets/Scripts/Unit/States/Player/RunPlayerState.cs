using UnityEngine;

namespace Game
{
    public class RunPlayerState : BasePlayerState
    {
        public override float MultiplayX => 2f;

        public RunPlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Run);
        }

        public override void Update()
        {
            base.Update();

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

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Machine.Switch(new WalkPlayerState(Controller));
                return;
            }
        }
    }
}