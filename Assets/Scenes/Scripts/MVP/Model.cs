using UnityEngine;
using System;

public interface IModel<T>
{
    public T Data { get; }

    public void Init();
    public T Copy();
    public void Set(T data);
}

[Serializable]
public class Model<T> : IModel<T>
{
    [field: SerializeField] public T Data { get; protected set; }

    public virtual void Init() { }
    public virtual T Copy() => Data;
    public virtual void Set(T data) => Data = data;
}