using UnityEngine;

namespace Game
{
    public class DeadPlayerState : UnitState
    {
        public DeadPlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            Animator.enabled = false;
            Controller.Owner.IsGroundedSetting.SetDistance(.43f);
            Controller.Owner.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        public override void Update()
        {
            base.Update();

            if (Controller.Owner.IsGrounded)
            {
                Rigidbody.simulated = false;
                Collider.isTrigger = true;
                Controller.Owner.SetController(null);
                if (!Controller.Owner.Hand.Empty)
                    Controller.Owner.Hand.Destroy();
                return;
            }
        }
    }
}