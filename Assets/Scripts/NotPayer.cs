using Game.StateMachine.State;
using Game.StateMachine;
using UnityEngine;
using Game.Data;

namespace Game.Gameplay.Units
{
    public class NotPayer : MonoBehaviour
    {
        [SerializeField] private Stats _stats;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] public float _groundedRadius = 0.2f;
        [SerializeField] public LayerMask _ground;
        [SerializeField] public Vector3 _groundCheck;

        private Stats _runtimeStats;
        private ContextStateMachine _context;

        private void Awake()
        {
            _runtimeStats = _stats.Copy<Stats>();
            _context = new ContextStateMachine();
            _context.States.Add(new PlayerIdle(_context));
            _context.States.Add(new PlayerMove(_context, _rigidbody, _runtimeStats));
            _context.FindToChange(typeof(PlayerIdle));
            _context.AStates.Add(new PlayerRotate(_context, _rigidbody, _runtimeStats));
        }

        private void Update()
        {
            _context?.Update();
        }
    }
}