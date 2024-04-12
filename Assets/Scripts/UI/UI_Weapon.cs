using System.Collections.Generic;
using UnityEngine.UI;
using Game.Weapons;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class UI_Weapon : MonoZenjectConstructor
    {
        [field: SerializeField] public Image Health { get; private set; }
        [field: SerializeField] public Image Ammo { get; private set; }
        [field: SerializeField] public UnitPlayer Player { get; private set; }
        [field: SerializeField] public List<Sprite> AmmoSprites { get; private set; }

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

            Health.fillAmount = (1f / Player.Stats.Health.Max) * Player.Stats.Health.Value;

            if (Player != null & !Player.Hand.Empty & (_weapon = Player.Hand.ItemHand as Weapon))
            {
                Ammo.sprite = AmmoSprites[(int)_weapon.Magazine.Amount];
            }
        }
    }
}