using UnityEngine;

namespace Game
{
    public class SitdownPlayerState : UnitState
    {
        private BoxCollider2D _boxCollider2D;
        private Vector2 _offset;
        private Vector2 _size;
        private Vector2 _defaultSize;

        public SitdownPlayerState(IUnitController controller) : base(controller)
        {
            _offset = new(0, .09f);
            _size = new(.5f, 1.75f);
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Sitdown);
            _boxCollider2D = Collider as BoxCollider2D;
            _defaultSize = _boxCollider2D.size;
            _boxCollider2D.offset = _offset;
            _boxCollider2D.size = _size;
        }

        public override void Finish()
        {
            base.Finish();
            _boxCollider2D.offset = Vector2.zero;
            _boxCollider2D.size = _defaultSize;
        }

        public override void Update()
        {
            base.Update();

            if (Controller.Owner.IsDead)
            {
                Machine.Switch(new DeadPlayerState(Controller));
                return;
            }

            if (!Input.GetKey(KeyCode.S))
            {
                Machine.Switch(new IdlePlayerState(Controller));
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && Controller.Owner.IsGrounded)
            {
                Machine.Switch(new JumpPlayerState(Controller));
                return;
            }
        }
    }
}