using System;
using Unit;
using UnityEngine;

namespace StateMachine.States
{
    public class Move : BaseState
    {
        public event Action CompleteEvent;
        public event Action FailedEvent;

        private IMovable _movable;
        private Vector3 _target;

        public Move(IMovable movable) => _movable = movable;
        public void SetTarget(Vector3 target) => _target = target;
        

        public override void Enter()
        {
            _movable.Move(_target);
            _movable.OnCompletePathEvent += OnCompleteEvent;
            _movable.OnFailedPathEvent += OnFailedEvent;
        }
        public override void Tick(float tickTime)
        {
            _movable.Move(_target);
        }

        public override void Exit()
        {
            _movable.OnCompletePathEvent -= OnCompleteEvent;
            _movable.OnFailedPathEvent -= OnFailedEvent;
        }

        protected virtual void OnCompleteEvent() => CompleteEvent?.Invoke();

        protected virtual void OnFailedEvent() => FailedEvent?.Invoke();
    }
}