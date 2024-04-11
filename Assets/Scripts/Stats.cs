using UnityEngine;
using System;

namespace Game
{
    [Serializable]
    public class Stat<T>
    {
        public T Value;
        public T Max;

        public Stat(Stat<T> stat) : this(stat.Value, stat.Max) { }

        public Stat(T value, T max)
        {
            Value = value;
            Max = max;
        }
    }

    public interface IStats
    {
        public bool Dead { get; }
        public Stat<float> Health { get; }
        public Stat<float> MoralHealt { get; }
        public float Speed { get; }
        public float JumpPower { get; }
    }

    [Serializable]
    public class Stats : IStats, ICloneable
    {
        public virtual bool Dead => Health.Value <= 0;
        [field: SerializeField] public Stat<float> Health { get; private set; }
        [field: SerializeField] public Stat<float> MoralHealt { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpPower { get; private set; }

        public Stats(Stats stats)
        {
            Health = new Stat<float>(stats.Health);
            MoralHealt = new Stat<float>(stats.MoralHealt);
            Speed = stats.Speed;
            JumpPower = stats.JumpPower;
        }

        public object Clone()
        {
            return new Stats(this);
        }
    }
}