namespace Game
{
    public interface IUpdater
    {
        public void OnUpdate();
    }

    public abstract class Updater : IUpdater
    {
        public virtual void OnUpdate()
        {
        }
    }
}