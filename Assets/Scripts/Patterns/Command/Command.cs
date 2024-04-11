namespace Game
{
    public interface ICommand
    {
        public void Execute();
        public void Endo();
    }

    public abstract class Command : ICommand
    {
        public virtual void Execute()
        {
        }

        public virtual void Endo()
        {
        }

    }
}