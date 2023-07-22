using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Data
{

    [CreateAssetMenu(menuName = "Game/Data/Unit")]
    public class UnitModel : ScriptableObject, IReturn<UnitDataBox>
    {
        [field: SerializeField] public UnitData Data { get; private set; }

        public UnitDataBox Return() => new UnitDataBox(Data);
    }

    [Serializable]
    public struct UnitData
    {
        public string Name;
        [TextArea(5, 10)] public string Description;
        public Stats Stats;
        [HideInInspector] public List<Component> Components;
    }

    [Serializable]
    public class UnitDataBox
    {
        public UnitData Data;
        public UnitDataBox(UnitData data)
        {
            Data = data;
        }
    }
}