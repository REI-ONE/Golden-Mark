using Game.Weapons;
using System.Linq;
using Game.Audio;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStatePistolFire : UnitStateAttack
    {
        private IAudioController _audioController;
        private IWeapon _weapon;

        public UnitStatePistolFire(UnitDataBox data) : base(data)
        {
            StartAnimation = 5;
            _audioController = DataBox.Data.Components.FirstOrDefault(comp => comp.GetType().Equals(typeof(AudioController))) as AudioController;
            _weapon = DataBox.Data.Components.FirstOrDefault(comp => comp.GetType().Equals(typeof(Weapon))) as IWeapon;
        }

        public override void OnExit()
        {
            base.OnExit();

            if (_weapon.Fire())
                _audioController.PlaySound(_weapon.Data.SoundFire);
        }
    }
}