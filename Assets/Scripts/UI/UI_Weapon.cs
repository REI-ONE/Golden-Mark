using System.Collections.Generic;
using UnityEngine.UI;
using Game.Weapons;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class UI_Weapon : MonoZenjectConstructor
    {
        [field: SerializeField] public Image Pistol { get; private set; }
        [field: SerializeField] public Image Bullet { get; private set; }
        [field: SerializeField] public UnitPlayer Player { get; private set; }
        [field: SerializeField] public List<Sprite> Bullets { get; private set; }

        private Weapon _weapon;

        [Inject]
        public override void Consturctor(DiContainer diContainer)
        {
            base.Consturctor(diContainer);
        }

        private void Update()
        {
            if (Player == null)
            {
                Player = DiContainer.TryResolveId<Unit>("Player") as UnitPlayer;
            }

            if (Player != null & !Player.Hand.Empty & (_weapon = Player.Hand.ItemHand as Weapon))
            {
                Pistol.fillAmount = (1f / 6) * _weapon.Magazine.Amount;
                Bullet.sprite = Bullets[(int)_weapon.Magazine.Amount];
            }
        }
    }
}