public interface IPresentar<T, U>
{
    public T Model { get; }
    public U View { get; }
}

public class Presentar<T, U> : IPresentar<T, U>
{
    public T Model { get; protected set; }
    public U View { get; protected set; }
}