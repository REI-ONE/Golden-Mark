using System;

namespace Game.Callbacks
{
    public interface IStateCallback
    {
        public event Action Enter;
        public event Action Exit;
        public event Action Update;
        public event Action FixedUpdate;
    }

    public abstract class StateCallback : IStateCallback
    {
        public virtual event Action Enter;
        public virtual event Action Exit;
        public virtual event Action Update;
        public virtual event Action FixedUpdate;
    }
}