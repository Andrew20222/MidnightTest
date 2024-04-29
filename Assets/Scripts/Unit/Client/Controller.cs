using System;
using Items.Model;
using Observer;
using Pool;
using StateMachine;
using StateMachine.States;
using Unit.Client.States;
using UnityEngine;

namespace Unit
{
    public class Controller : InteractableElement, IClient
    {
        public Data Item { get; private set; }

        [SerializeField] private Movement movement;

        private Observer.Observer _interactableObserver;
        private IObserverListenable _listenable;
        
        private StateMachine<BaseState> _stateMachine;
        private Move _move;
        private Idle _idle;
        private SitDown _sitDown;
        
        private Transform _target;
        private bool _isComplete;

        private void Awake()
        {
            _stateMachine = new StateMachine<BaseState>();
        }
        
        private void Start()
        {
            _listenable = _interactableObserver;
            _move = new Move(movement);
            _idle = new Idle();

            _stateMachine.ChangeState(_idle);
            _stateMachine.AddTransition(_move, TargetCheck);
            _stateMachine.AddTransition(_move,_sitDown,CheckCompletePath);
            _stateMachine.AddTransition(_idle, CheckTargetNull);

            _listenable.Subscribe(() =>
            {
                _stateMachine.AddTransition(_move,TargetCheck);
            });
            
            _move.CompleteEvent += CompletePath;
            _move.FailedEvent += FailedPath;
        }

        private void Update() => _stateMachine.Tick(Time.deltaTime);
        private bool TargetCheck() => _target != null;
        private bool CheckTargetNull() => _target == null;
        private void CompletePath() => _isComplete = true;
        private void FailedPath() => Debug.LogError("FAILED_PATH", gameObject);

        public void SetTarget(Transform target)
        {
            if(target == null) return;
            
            _target = target;
            _move.SetTarget(_target.position);
        }

        private void ClearTarget() => _target = transform;
        private bool CheckCompletePath() => _isComplete;
        public void SitDown() => ClearTarget();
        public void SetItem(Data item) => Item = item;
        public override void SetObserver(Observer.Observer interactableObserver) 
            => _interactableObserver = interactableObserver;
    }
}