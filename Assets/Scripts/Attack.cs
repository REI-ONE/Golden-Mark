using Game.Data;

namespace Game
{
    public struct AttackData
    {
        public Unit Attacker;
        public SOAmmo Ammo;
        public float Damage;

        public AttackData(Unit attacker, SOAmmo ammo, float damage)
        {
            Attacker = attacker;
            Ammo = ammo;
            Damage = damage;
        }

        public AttackData(AttackData attack) : this(attack.Attacker, attack.Ammo, attack.Damage) { }

        public override string ToString()
        {
            return $"Attacker {Attacker} , Damage {Damage} , ammo {Ammo.Model.Data.Name} ";
        }
    }

    public class Attack : Model<AttackData>
    {
        public Attack(AttackData attack)
        {
            Set(attack);
        }
    }
}