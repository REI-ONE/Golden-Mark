using UnityEngine;

namespace Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] public Game.StateMachine.ContextStateMachine stateMachine = new Game.StateMachine.ContextStateMachine();
        [SerializeField] private Stats _stats = new Stats();
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] public float _groundedRadius = 0.2f;
        [SerializeField] public LayerMask _ground;
        [SerializeField] public Vector3 _groundCheck;
        private StateMachine _stateMachine;
        private InputAxis _inputAxis = new InputAxis();
        private IState _idleState, _moveState, _jumpState, _dashState;

        //[Inject]
        //public void Construct(SO.MoveState moveState)
        //{
        //    SO.MoveState state = ScriptableObject.CreateInstance(moveState.GetType()) as SO.MoveState;
        //    state.Init(_rigidbody, ref _inputAxis, ref _stats);
        //    _moveState = state;
        //}

        private void Awake()
        {
            _idleState = new IdleState();
            _jumpState = new JumpState(_rigidbody, ref _inputAxis, ref _stats);
            _moveState = new MoveState(_rigidbody, ref _inputAxis, ref _stats);
            _dashState = new DashState(this, _rigidbody, ref _inputAxis, ref _stats);

            _stateMachine = new StateMachine(_idleState);
        }
        private void FixedUpdate()
        {
            CheckGround();
            _stateMachine.CurrentState.FixedUpdate();
        }

        private void LateUpdate() => _stateMachine.CurrentState.LateUpdate();

        private void Update()
        {
            InputAxis();
            _stateMachine.CurrentState.Update();
            SwitchState();
            //print(_stateMachine.CurrentState);
        }

        private void SwitchState()
        {
            switch (_stateMachine.CurrentState)
            {
                case IdleState:
                    if (Mathf.Abs(_inputAxis.x) > 0) _stateMachine.ChangeState(_moveState);
                    if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_jumpState);
                    if (Input.GetKeyDown(KeyCode.LeftShift)) _stateMachine.ChangeState(_dashState);
                    break;
                case MoveState:
                    if (_inputAxis.x == 0) _stateMachine.ChangeState(_idleState);
                    if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_jumpState);
                    if (Input.GetKeyDown(KeyCode.LeftShift)) _stateMachine.ChangeState(_dashState);
                    break;
                case JumpState:
                    _stateMachine.ChangeState(_idleState);
                    //if (Mathf.Abs(_inputAxis.x) > 0) _stateMachine.ChangeState(_moveState);
                    break;
                case DashState:
                    if (!_stats.IsDashing) _stateMachine.ChangeState(_idleState);
                    break;
            }
        }
        private void InputAxis() => _inputAxis.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + _groundCheck, _groundedRadius, _ground);

            if (colliders.Length == 0) _stats.Grounded = false;

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    _stats.Grounded = true;
                if (!_stats.Grounded)
                {
                    //OnLandEvent.Invoke();
                    //if (!_stats.IsDashing)
                    //    particleJumpDown.Play();
                    _stats.CanDoubleJump = true;
                }
            }
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + _groundCheck, _groundedRadius);
        }

        [System.Serializable]
        public class Stats
        {
            [field: SerializeField] public float MovementSpeed { get; set; } = 10f;
            [field: SerializeField] public float MovementSmoothing { get; set; } = 0f;
            [field: SerializeField] public float JumpForce { get; set; } = 400f;
            [field: SerializeField] public bool AirControl { get; set; } = true;
            [field: SerializeField] public float AirControlSmoothing { get; set; } = 0.5f;
            [field: SerializeField] public float DashForce { get; set; } = 25f;
            [field: SerializeField] public float DashTime { get; set; } = 0.5f;
            [field: SerializeField] public float DashCooldown { get; set; } = 3f;
            public bool FacingRight { get; set; } = true;
            public bool CanMove { get; set; } = true;
            public bool Grounded { get; set; } = false;
            public bool Jump { get; set; } = false;
            public bool CanDoubleJump { get; set; } = false;
            public bool CanDash { get; set; } = true;
            public bool Dash { get; set; } = false;
            public bool IsDashing { get; set; } = false;
            public float LimitFallSpeed { get; set; } = 25f;
        }
    }

    public class InputAxis
    {
        public float y { get; private set; } = 0;
        public float x { get; private set; } = 0;

        public Vector2 Vector2 => new Vector2(x, y);

        public void Set(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
