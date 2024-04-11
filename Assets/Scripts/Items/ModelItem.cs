using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public struct ItemData
    {
        public Sprite Icon;
        public string Name;
        [TextArea(5, 10)] public string Description;
    }

    [Serializable]
    public class ModelItem : Model<ItemData>
    {
    }
}