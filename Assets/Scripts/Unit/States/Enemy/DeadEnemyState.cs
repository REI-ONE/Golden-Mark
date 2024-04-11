namespace Game
{
    public class DeadEnemyState : DeadPlayerState
    {
        public DeadEnemyState(IUnitController controller) : base(controller)
        {
        }

        public override void Start()
        {
            base.Start();
            if (!Controller.Owner.Hand.Empty)
            {
                Controller.Owner.Hand.Destroy();
            }
        }
    }
}