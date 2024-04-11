using UnityEngine;
using Game.Data;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Data/Weapon/Weapon")]
    public class SOWeapon : SOItem
    {
        [field: SerializeField] public float DelayBetweenShots { get; private set; }
        [field: SerializeField] public SOMagazine SOMagazine { get; private set; }
    }
}