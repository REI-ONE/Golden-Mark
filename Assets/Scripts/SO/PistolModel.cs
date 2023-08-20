using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Weapon/Pistol")]
    public class PistolModel : WeaponModel
    {
        [field: SerializeField] public PistolBox PistolBox;
    }

    [System.Serializable]
    public struct PistolBox
    {
        public float Damage;
        public float Speed;
        public int Amount;
        public int MaxAmount;
        public AudioClip SoundFire;
        public AudioClip SoundReload;
    }
}