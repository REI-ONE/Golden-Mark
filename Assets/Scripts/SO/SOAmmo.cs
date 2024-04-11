using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Weapon/Ammo")]
    public class SOAmmo : SOBaseItem
    {
        [field: SerializeField] public ModelAmmo Model { get; private set; }
    }
}