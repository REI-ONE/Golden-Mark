namespace Game.UI.View
{
    public interface IView
    {
        public void Show();
        public void Hide();
    }

    public interface IViewPresentar : IView
    {
        public IPresenatar Presenatar { get; }
        public void SetPresentar(IPresenatar presenatar);
    }

    public abstract class BaseView : MonoInitialization, IView
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }

    public abstract class ViewPresentar : BaseView, IViewPresentar
    {
        public IPresenatar Presenatar { get; private set; }

        public virtual void SetPresentar(IPresenatar presenatar)
        {
            Presenatar = presenatar;
        }
    }
}