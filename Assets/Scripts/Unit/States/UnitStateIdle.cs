using System.Linq;
using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateIdle : UnitState
    {
        public Animator Animator { get; protected set; }
        public string NameAnimation { get; protected set; } = "index";
        public int StartAnimation { get; protected set; } = 0;
        public int EndAnimation { get; protected set; } = 0;

        public UnitStateIdle(UnitDataBox data) : base(data)
        {
            Animator = DataBox.Data.Components.SingleOrDefault(comp => comp.GetType().Equals(typeof(Animator))) as Animator;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Animator.SetInteger(NameAnimation, StartAnimation);
        }

        public override void OnExit()
        {
            base.OnExit();
            Animator.SetInteger(NameAnimation, EndAnimation);
        }
    }
}