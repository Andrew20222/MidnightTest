using System;
using StateMachine.States;

namespace StateMachine.Transitions
{
    public abstract class Transition<TState> where TState : BaseState
    {
        public TState To { get; }
        private Predicate<TState> _predicate;

        public Transition(TState to)
        {
            To = to;
        }

        public abstract bool Validate(TState current);
    }
}