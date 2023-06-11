using UnityEngine;
using Zenject;

namespace Test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Stats _stats = new Stats();
        private StateMachine _stateMachine;
        [SerializeField] private Rigidbody2D _rigidbody;
        private InputAxis _inputAxis = new InputAxis();

        private IState _idleState, _moveState, _jumpState;

        [Inject]
        public void Construct(SO.MoveState moveState)
        {
            SO.MoveState state = ScriptableObject.CreateInstance(moveState.GetType()) as SO.MoveState;
            state.Init(_rigidbody, ref _inputAxis, ref _stats);
            _moveState = state;
        }

        private void Awake()
        {
            _idleState = new IdleState();
            _jumpState = new JumpState();
            //_moveState = new MoveState(_rigidbody, ref _inputAxis, ref _stats);
            
            _stateMachine = new StateMachine(_idleState);
        }

        private void Update()
        {
            InputAxis();
            StateSwitcher();
        }

        private void InputAxis() => _inputAxis.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        private void StateSwitcher()
        {
            _stateMachine.CurrentState.Update();

            switch (_stateMachine.CurrentState)
            {
                case IdleState:
                    if (Mathf.Abs(_inputAxis.x) > 0) _stateMachine.ChangeState(_moveState);

                    if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_jumpState);
                    break;
                case MoveState:
                    if (_inputAxis.x == 0) _stateMachine.ChangeState(_idleState);
                    break;
                case JumpState:
                    if (_inputAxis.x == 0) _stateMachine.ChangeState(_idleState);
                    //if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(new JumpState());
                    break;
            }
        }
    }

    [System.Serializable]
    public class Stats {
        [field: SerializeField] public float Smoothing { get; private set; } = 0;
    }

    public class InputAxis
    {
        public float y { get; private set; } = 0;
        public float x { get; private set; } = 0;

        public Vector2 Get => new Vector2(x, y);

        public void Set(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
