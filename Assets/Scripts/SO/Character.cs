using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Character")]
    public class Character : SOInitialization
    {
        [field: SerializeField] public ModelUnit Model { get; private set; }
        [field: SerializeField] public Unit UnitPrefab { get; private set; }
        [field: SerializeField] public SOWeapon SOWeapon { get; private set; }
    }
}