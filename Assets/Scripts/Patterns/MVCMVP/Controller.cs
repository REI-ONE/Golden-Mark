using Game.UI.View;

namespace Game
{
    public interface IController
    {
        public IModel Model { get; }
        public IView View { get; }
    }

    public abstract class Controller : Initialization, IController
    {
        public IModel Model { get; private set; }
        public IView View { get; private set; }

        public Controller(IModel model, IView view)
        {
            Model = model;
            View = view;
        }
    }
}