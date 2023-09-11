using System.Collections.Generic;
using Game.Gameplay.Units;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private Image _bulletPanel;
        [SerializeField] private Sprite[] _bulletSprites;

        private PlayerUnit _player;

        [Inject]
        public void Construct(PlayerUnit player) => _player = player;
        private void OnEnable() => _player.Weapon.Executed += WeaponExecuted;
        private void OnDisable() => _player.Weapon.Executed -= WeaponExecuted;
        public void WeaponExecuted(int bullets) => _bulletPanel.sprite = _bulletSprites[bullets];
    }
}