using Game.Data;

namespace Game
{
    public class UnitEnemy : UnitDamageHit
    {
        public override void Init(Character data)
        {
            base.Init(data);
            SetController(new EnemyUnitController());
        }
    }
}