using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public struct UnitData
    {
        public Sprite Portraite;
        public string Name;
        [TextArea(5, 10)] public string Description;
        [field: SerializeField, Header("Это данные игрока?")] public bool Hero { get; private set; }
        [field: SerializeField] public Stats Stats { get; private set; }
    }

    [Serializable]
    public class ModelUnit : Model<UnitData>
    {
    }
}