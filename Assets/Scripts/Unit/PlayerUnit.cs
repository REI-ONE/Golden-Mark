using Game.Weapons;
using UnityEngine;
using Game.Audio;
using Game.Data;
using Zenject;

namespace Game.Gameplay.Units
{
    public class PlayerUnit : Unit
    {
        [SerializeField] private UnitModel _data;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Weapon _weapon;

        private IAudioController _audioController;

        private void Start()
        {
            Init(_data.Return());
        }

        [Inject]
        public void Construct(IAudioController audioController) => _audioController = audioController;

        public override void Init(UnitDataBox data)
        {
            base.Init(data);
            DataBox.Data.Components.Add(_animator);
            DataBox.Data.Components.Add(_rigidbody2D);
            DataBox.Data.Components.Add(transform);
            DataBox.Data.Components.Add(_audioController.Type);
            DataBox.Data.Components.Add(_weapon);

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