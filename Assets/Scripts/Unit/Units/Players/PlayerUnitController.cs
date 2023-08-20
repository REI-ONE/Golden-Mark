using Game.StateMachine.State;
using Game.Environment;
using UnityEngine;
using System.Linq;
using Game.Data;

namespace Game.Gameplay.Units
{
    public class PlayerUnitController : UnitController
    {
        private Transform _transform;
        private Vector2 _rotate;

        private UnitStateIdle _idle;
        private UnitStateWalk _walk;
        private UnitStateRun _run;
        private UnitStateJump _jump;
        private UnitStatePistolFire _pistolFire;
        private UnitStatePistolreload _pistolReload;

        public PlayerUnitController(UnitDataBox data)
        {
            Init(data);
            _transform = DataBox.Data.Components.SingleOrDefault(comp => comp.GetType().Equals(typeof(Transform))) as Transform;
            _idle = new UnitStateIdle(DataBox);
            _walk = new UnitStateWalk(DataBox);
            _run = new UnitStateRun(DataBox);
            _jump = new UnitStateJump(DataBox);
            _pistolFire = new UnitStatePistolFire(DataBox);
            _pistolReload = new UnitStatePistolreload(DataBox);

            Switch(_idle);
        }

        public virtual bool IsGround()
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(_transform.position, Vector2.down, _transform.localScale.y * 1.5f);

            if (hit != null && (hit.Length > 0))
            {
                Ground ground = null;
                hit.SingleOrDefault(hit => hit.collider.TryGetComponent<Ground>(out ground));

                if (ground != null)
                    return true;
            }

            return false;
        }

        public virtual void Rotate()
        {
            _rotate = _transform.localScale;

            if (Input.GetAxis("Horizontal") > 0f && _rotate.x < 0f)
                _rotate.x *= -1;
            else if (Input.GetAxis("Horizontal") < 0f && _rotate.x > 0f)
                _rotate.x *= -1;

            _transform.localScale = _rotate;
        }

        public override void Monitoring()
        {
            base.Monitoring();
            Rotate();

            if (Input.GetMouseButtonDown(0))
                Switch(_pistolFire);
            else if (Input.GetMouseButton(1))
                Switch(_pistolReload);
            else if (Input.GetKeyDown(KeyCode.Space) && IsGround())
                Switch(_jump);
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0f)
                Switch(_run);
            else if (Input.GetAxis("Horizontal") != 0f)
                Switch(_walk);
            else
                Switch(_idle);
        }

        public override void Switch(IState state)
        {
            if (Curent != null && state.GetType().Equals(Curent.GetType()))
                return;

            base.Switch(state);
        }
    }
}