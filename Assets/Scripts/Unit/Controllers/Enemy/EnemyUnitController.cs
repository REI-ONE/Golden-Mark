namespace Game
{
    public class EnemyUnitController : UnitController
    {
        public override void Init(Unit data)
        {
            base.Init(data);
            Switch(new ScaningEnemyState(this));
        }
    }
}