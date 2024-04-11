using Game.HamdItems;
using UnityEngine;

namespace Game.Data
{
    public abstract class SOBaseItem : SOInitialization
    {
        [field: SerializeField] public PickUpItem PrefabUp { get; private set; }
        [field: SerializeField] public ItemHand PrefabHand { get; private set; }

        private void OnValidate()
        {
            if ((PrefabUp != null))
            {
                PrefabUp.Init(this);
            }

            if ((PrefabHand != null))
            {
                PrefabHand.Init(this);
            }
        }
    }

    [CreateAssetMenu(menuName = "Game/Data/Item")]
    public class SOItem : SOBaseItem
    {
        [field: SerializeField] public ModelItem Model { get; private set; }
    }
}