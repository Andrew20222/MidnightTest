using StateMachine.States;

namespace StateMachine
{
    public interface IStateEventHandler<TState>
        where TState : BaseState
    {
        public void Construct(StateMachine<TState> stateMachine);
    }
}