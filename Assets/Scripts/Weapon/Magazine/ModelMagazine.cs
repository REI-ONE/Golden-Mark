using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public struct MagazineData
    {
        public Sprite Icon;
        public string Name;
        [TextArea(5, 10)] public string Description;
        public Stat<float> Amount;
        public float Reloading;
    }

    [Serializable]
    public class ModelMagazine : Model<MagazineData>
    {
        public override void Set(MagazineData data)
        {
            MagazineData magazine = data;
            magazine.Amount = new Stat<float>(data.Amount);
            base.Set(magazine);
        }
    }
}