using UnityEngine;

namespace Game
{
    public class BasePlayerState : UnitState
    {
        public BasePlayerState(IUnitController controller) : base(controller)
        {
        }

        public override void Update()
        {
            base.Update();
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 velocity = new Vector2(horizontal * (Controller.Owner.Stats.Speed * MultiplayX), Rigidbody.velocity.y);
            Rigidbody.velocity = velocity;
        }
    }
}