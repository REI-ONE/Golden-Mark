namespace Game
{
    public interface IModel { }
    public interface IModel<T> : IModel, IInitialization<T>
    {
        public T Copy();
        public void Set(T data);
        public T Get();
    }

    public abstract class Model<T> : IModel<T>
    {
        public T Data;

        public virtual void Init(T data) { }

        public virtual T Get()
        {
            return Data;
        }

        public virtual void Set(T data)
        {
            Data = default;
            Data = data;
        }

        public virtual T Copy()
        {
            T data = Data;
            return data;
        }
    }
}