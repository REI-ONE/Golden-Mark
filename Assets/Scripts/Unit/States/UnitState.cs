using UnityEngine;

namespace Game
{
    public class UnitState : State
    {
        public virtual float MultiplayX { get; protected set; } = 1f;
        public IUnitController Controller { get; private set; }
        public Collider2D Collider { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }

        public UnitState(IUnitController controller)
        {
            Machine = controller as StateMachine;
            Controller = controller;
            Collider = controller.Owner.Collider;
            Animator = controller.Owner.Animator;
            Rigidbody = controller.Owner.Rigidbody;
        }
    }
}