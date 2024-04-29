using System;
using StateMachine.States;

namespace StateMachine
{
    public class StateMachine<TState> : ITransitionManager<TState> where TState : BaseState
    {
        private readonly float _tickTimeStep;
        private TState _currentState;
        private float _timeNextTick;
        private ITransitionManager<TState> _transitionManager;
        public StateMachine(float tickStep = 0)
        {
            _tickTimeStep = tickStep;
            _transitionManager = new DefaultTransitionManager<TState>();
        }
        
        public StateMachine(ITransitionManager<TState> transitionManager, float tickStep = 0)
        {
            _tickTimeStep = tickStep;
            _transitionManager = transitionManager;
        }

        public void Tick(float tickTime)
        {
            if (_tickTimeStep > _timeNextTick) return;

            if (_transitionManager.FindTransition(_currentState, out var nextState))
            {
                ChangeState(nextState);
                _timeNextTick = 0;
            }
            else
            {
                _timeNextTick += tickTime;
                _currentState.Tick(tickTime);
            }
        }

        public void ChangeState(TState newState)
        {
            if (newState == _currentState)
            {
                return;
            }

            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();

            _transitionManager.RunTransitionFor(newState);
        }

        void ITransitionManager<TState>.RunTransitionFor(TState newState)
        {
            _transitionManager.RunTransitionFor(newState);
        }

        bool ITransitionManager<TState>.FindTransition(TState currentState, out TState nextState)
        {
            return _transitionManager.FindTransition(currentState, out nextState);
        }

        public void AddTransition(TState @from, TState to, Func<bool> predicate)
        {
            _transitionManager.AddTransition(@from, to, predicate);
        }

        public void AddTransition(TState to, Func<bool> predicate)
        {
            _transitionManager.AddTransition(to, predicate);
        }
    }

    public class StateMachine<TState, TEventHandler> : StateMachine<TState> where TState : BaseState
        where TEventHandler : IStateEventHandler<TState>, new()
    {
        public TEventHandler EventHandler { get; }
        
        public StateMachine(float tickStep = 0) : base(tickStep)
        {
            EventHandler = new TEventHandler();
            EventHandler.Construct(this);
        }
        
        public StateMachine(ITransitionManager<TState> transitionManager, float tickStep = 0) : base(transitionManager, tickStep)
        {
            EventHandler = new TEventHandler();
            EventHandler.Construct(this);
        }
    }
}