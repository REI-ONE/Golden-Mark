using System.Collections.Generic;
using System.Collections;
using Game.Setting;
using UnityEngine;

namespace Game.Data
{
    public interface IGameSetting
    {
        public IPause Pause { get; }
    }

    [CreateAssetMenu(menuName = "Game/Data/GameSetting")]
    public class GameSetting : BaseMySO, IGameSetting
    {
        [SerializeField] private Pause _pause;
        public IPause Pause => _pause;
    }
}