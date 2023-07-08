namespace Game.StateMachine.State
{
    public class PlayerIdle : ContextState
    {
        public PlayerIdle(ContextStateMachine state) : base(state) { }

        public override void Enter()
        {
        }

        public override void Exite()
        {
        }

        public override void Update()
        {
            if (UnityEngine.Input.GetAxis("Horizontal") > 0.1f)
                Context?.FindToChange(typeof(PlayerMove));

            if (UnityEngine.Input.GetAxis("Horizontal") < -0.1f)
                Context?.FindToChange(typeof(PlayerMove));
        }
    }
}