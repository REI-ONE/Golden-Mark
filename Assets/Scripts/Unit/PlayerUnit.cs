using UnityEngine;
using Game.Data;

namespace Game.Gameplay.Units
{
    public class PlayerUnit : Unit
    {
        [SerializeField] private UnitModel _data;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            Init(_data.Return());
        }

        public override void Init(UnitDataBox data)
        {
            base.Init(data);
            DataBox.Data.Components.Add(_animator);
            DataBox.Data.Components.Add(_rigidbody2D);
            DataBox.Data.Components.Add(transform);

            Controller = new PlayerUnitController(DataBox);
        }

        private void Update()
        {
            Controller?.Monitoring();
        }

        private void FixedUpdate()
        {
            Controller?.FixedMonitoring();
        }
    }
}