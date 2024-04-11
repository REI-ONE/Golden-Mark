using System.Text;
using UnityEngine;

namespace Game
{
    public interface IUnitDamageHit : IDamageHit<AttackData?>
    {
        public StringBuilder DamageHistory { get; }
    }

    public abstract class UnitDamageHit : Unit, IUnitDamageHit
    {
        public StringBuilder DamageHistory { get; private set; } = new StringBuilder(4);

        public virtual void Damage(AttackData? attack)
        {
            if (!attack.HasValue)
                return;

            DamageHistory.Append($"{attack.Value}/n");
            Stats.Health.Value -= attack.Value.Damage;
            Stats.Health.Value = Mathf.Clamp(Stats.Health.Value, 0, Stats.Health.Max);
        }

        public virtual void Kill(AttackData? attack)
        {
            if (!attack.HasValue)
                return;

            AttackData data = attack.Value;
            data.Damage = Stats.Health.Value;
            Damage(data);
        }

        public virtual void Kill()
        {
            AttackData data = new() { Attacker = this, Damage = 0, Ammo = null };
            Kill(data);
        }
    }
}