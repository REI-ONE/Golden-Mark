using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.StateMachine
{
    public class ContextStateMachine
    {
        public ContextState Curent;
        public List<ContextState> States { get; set; } = new List<ContextState>(10);
        public AsynchronousStates AStates { get; private set; } = new AsynchronousStates();

        public void Init(ContextState state)
        {
            Curent = state;
            Curent.Enter();
        }

        public void FindToChange(Type type)
        {
            foreach (ContextState state in States)
            {
                if (state.GetType().Equals(type))
                {
                    Debug.Log($"State {type} Found!");
                    Change(state);
                    return;
                }
            }

            Debug.Log($"State {type} not Found!");
        }

        public void Change(ContextState state)
        {
            Curent?.Exite();
            Curent = state;
            Curent?.Enter();
        }

        public void Update()
        {
            Curent?.Update();
            AStates?.Update();
        }
    }

    public abstract class ContextState
    {
        private protected ContextStateMachine Context { get; set; }
        public ContextState(ContextStateMachine context)
        {
            Context = context;
        }

        public abstract void Enter();
        public abstract void Exite();
        public virtual void Update() { }
    }

    public abstract class AsynchronousContextState : ContextState
    {
        protected AsynchronousContextState(ContextStateMachine context) : base(context)
        {
        }
    }

    public class AsynchronousStates
    {
        public List<AsynchronousContextState> States { get; private set; } = new List<AsynchronousContextState>(10);

        public void Add(AsynchronousContextState state)
        {
            state.Enter();
            States.Add(state);
        }

        public void Remove(AsynchronousContextState state)
        {
            if (States.Remove(state))
                state.Exite();
        }

        public void Update()
        {
            for (int i = States.Count - 1; i >= 0; i--)
                States[i]?.Update();
        }
    }
}