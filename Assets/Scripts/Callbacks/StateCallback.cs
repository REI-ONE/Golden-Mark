using System;

namespace Game.Callbacks
{
    public interface IStateCallback
    {
        public event Action Enter;
        public event Action Exit;
        public event Action Update;
    }

    public abstract class StateCallback : IStateCallback
    {
        public virtual event Action Enter;
        public virtual event Action Exit;
        public virtual event Action Update;
    }
}