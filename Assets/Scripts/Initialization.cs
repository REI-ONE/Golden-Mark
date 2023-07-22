namespace Game
{
    public interface IInitialization<T>
    {
        public void Init(T data);
    }

    public interface IReturn<T>
    {
        public T Return();
    }

    public abstract class Initialization<T> : IInitialization<T>
    {
        public T Data;
        public virtual void Init(T data) => Data = data;
    }
}