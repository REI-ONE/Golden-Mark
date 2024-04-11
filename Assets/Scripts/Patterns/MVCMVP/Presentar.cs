using Game.UI.View;

namespace Game
{
    public interface IPresenatar
    {
        public IModel Model { get; }
        public IViewPresentar View { get; }
    }

    public abstract class Presentar : Initialization, IPresenatar
    {
        public IModel Model { get; private set; }
        public IViewPresentar View { get; private set; }

        public Presentar(IModel model, IViewPresentar view)
        {
            Model = model;
            View = view;
        }
    }
}