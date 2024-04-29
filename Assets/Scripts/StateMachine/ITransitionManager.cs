using System;
using StateMachine.States;

namespace StateMachine
{
    public interface ITransitionManager<TState> where TState : BaseState
    {
        public void RunTransitionFor(TState newState);
        public void AddTransition(TState from, TState to, Func<bool> predicate);
        public void AddTransition(TState to, Func<bool> predicate);
        public bool FindTransition(TState currentState, out TState nextState);
    }
}