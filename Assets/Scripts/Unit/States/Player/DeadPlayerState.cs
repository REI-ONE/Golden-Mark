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

                Machine.Switch(null);
                return;
            }
        }
    }
}