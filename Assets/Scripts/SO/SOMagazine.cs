using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Weapon/Magazine")]
    public class SOMagazine : SOBaseItem
    {
        [field: SerializeField] public SOAmmo SOAmmo { get; private set; }
        [field: SerializeField] public ModelMagazine Model { get; private set; }
    }
}