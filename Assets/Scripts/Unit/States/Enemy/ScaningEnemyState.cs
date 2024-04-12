using UnityEngine;

namespace Game
{
    public class ScaningEnemyState : BaseAttackEnemyState
    {
        public float TimeDelay { get; protected set; }
        public Stat<float> RadiusScanning { get; protected set; }

        protected float _radius;
        protected float _time;

        public ScaningEnemyState(IUnitController controller) : base(controller)
        {
            RadiusScanning = new Stat<float>(1f, 5f);
            _radius = RadiusScanning.Value;
            _time = TimeDelay = 5f;
        }

        public override void Start()
        {
            base.Start();
            Animator.SetInteger(Animations.Key, Animations.Idle);
        }

        public bool Scanning()
        {
            if (_time > 0f)
            {
                _time -= Time.deltaTime;
                _radius += Time.deltaTime;
                _radius = Mathf.Clamp(_radius, RadiusScanning.Value, RadiusScanning.Max);
            }

            Vector2 pos = Controller.Owner.transform.position;
            RaycastHit2D[] ray = Physics2D.RaycastAll(pos, Vector2.right, _radius);

            if (ray.Length > 0)
            {
                foreach (RaycastHit2D raycast in ray)
                {
                    if (raycast.collider.TryGetComponent<UnitPlayer>(out UnitPlayer player))
                    {
                        Attack(player.transform);
                    }
                }
            }

            if (_time < 0f)
            {
                _time = TimeDelay;
                _radius = RadiusScanning.Value;
                return false;
            }

            return true;
        }

        public override void Update()
        {
            base.Update();

            if (Controller.Owner.IsDead)
            {
                Controller.Switch(new DeadEnemyState(Controller));
                return;
            }

            if (!Scanning())
            {

            }
        }
    }
}