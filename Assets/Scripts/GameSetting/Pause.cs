using UnityEngine;

namespace Game.Setting
{
    public interface IPause
    {
        public bool IsPaused { get; set; }
    }

    [System.Serializable]
    public class Pause : IPause
    {
        [field: SerializeField] public bool IsPaused { get; set; }
    }
}