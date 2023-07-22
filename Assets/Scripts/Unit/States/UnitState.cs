using Game.Callbacks;
using Game.Data;
using System;

namespace Game.StateMachine.State
{
    public class UnitState : BaseState, IStateCallback
    {
        public UnitDataBox DataBox { get; protected set; }

        public event Action Enter;
        public event Action Exit;
        public event Action Update;
        public event Action FixedUpdate;

        public UnitState(UnitDataBox data)
        {
            DataBox = data;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Enter?.Invoke();
        }

        public override void OnExit()
        {
            base.OnExit();
            Exit?.Invoke();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Update?.Invoke();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            FixedUpdate?.Invoke();
        }
    }
}