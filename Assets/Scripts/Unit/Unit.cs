using UnityEngine;
using Game.Data;
using Zenject;

namespace Game
{
    public interface IUnit : IUpdater
    {
        public bool IsHero { get; }
        public bool IsDead { get; }
        public bool IsGrounded { get; }
        public Collider2D Collider { get; }
        public Animator Animator { get; }
        public Rigidbody2D Rigidbody { get; }
        public Character Character { get; }
        public DiContainer DiContainer { get; }
        public Stats Stats { get; }
        public IUnitController Controller { get; }
        public Hand Hand { get; }

        public void Construct(DiContainer container);
        public void SetController(IUnitController controller);
    }

    public abstract class Unit : MonoInitialization, IUnit, IInitialization<Character>
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Animator Animator { get; protected set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; protected set; }
        [field: SerializeField] public Character Character { get; protected set; }
        [field: SerializeField] public Stats Stats { get; protected set; }
        [field: SerializeField] public Hand Hand { get; private set; }
        [field: SerializeField] public IsGrounded IsGroundedSetting { get; protected set; }

        public virtual bool IsHero => Character.Model.Data.Hero;
        public virtual bool IsDead => Stats.Dead;
        public virtual bool IsGrounded => IsGroundedSetting.CheckGround(transform.position);

        public DiContainer DiContainer { get; protected set; }
        public IUnitController Controller { get; private set; }


        public void Construct(DiContainer container)
        {
            DiContainer = container;
        }

        public virtual void Init(Character data)
        {
            name = data.name;
            Character = data;
            Stats = data.Model.Data.Stats.Clone() as Stats;
            Hand.Init(this);
            Hand.Set(data.SOWeapon);
        }

        public virtual void OnUpdate()
        {
            Controller?.OnUpdate();
            Hand?.OnUpdate();
        }

        public virtual void SetController(IUnitController controller)
        {
            Controller = controller;
            Controller?.Init(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGroundedSetting.GizmosColor;
            Vector2 from = transform.position;
            Vector2 to = (Vector2)transform.position + IsGroundedSetting.Direction * IsGroundedSetting.Distance;
            Gizmos.DrawLine(from, to);
        }
    }
}