using Game.Data;

namespace Game
{
    public class UnitPlayer : UnitDamageHit
    {
        public override void Init(Character data)
        {
            base.Init(data);
            SetController(new PlayerUnitController());
        }
    }
}