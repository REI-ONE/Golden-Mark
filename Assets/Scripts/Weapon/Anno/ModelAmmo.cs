using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public struct AmmoData
    {
        public Sprite Icon;
        public string Name;
        [TextArea(5, 10)] public string Description;
        public float _lifeTime;
        public float Damage;
        public float Speed;
    }

    [Serializable]
    public class ModelAmmo : Model<AmmoData>
    {
    }
}