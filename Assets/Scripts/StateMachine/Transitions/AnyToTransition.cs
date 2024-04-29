using System;
using StateMachine.States;

namespace StateMachine.Transitions
{
    public class AnyToTransition<TState> : Transition<TState> where TState : BaseState
    {
        private Func<bool> _predicate;

        public AnyToTransition(TState to, Func<bool> predicate) : base(to)
        {
            _predicate = predicate;
        }

        public override bool Validate(TState current)
        {
            if (current == To)
            {
                return false;
            }

            return _predicate.Invoke();
        }
    }
}