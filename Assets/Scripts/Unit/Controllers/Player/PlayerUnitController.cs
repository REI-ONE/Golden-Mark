namespace Game
{
    public class PlayerUnitController : UnitController
    {
        public Aim Aim { get; private set; }

        public override void Init(Unit data)
        {
            base.Init(data);
            Aim = data.DiContainer.TryResolve<Aim>();
            Switch(new IdlePlayerState(this));
        }

        public override void Rotate()
        {
            base.Rotate();

            if (Owner.transform.position.x < Aim.transform.position.x)
            {
                Owner.transform.localScale = ScaleRotation.Right;
            }
            else if (Owner.transform.position.x > Aim.transform.position.x)
            {
                Owner.transform.localScale = ScaleRotation.Left;
            }
        }

        public override void OnUpdate()
        {
            Rotate();
            base.OnUpdate();
        }
    }
}