using System;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    public class Movement : MonoBehaviour, IMovable
    {
        public event Action OnCompletePathEvent;
        public event Action OnFailedPathEvent;

        [SerializeField] private NavMeshAgent agent;
        private bool _isActive;

        void IMovable.Move(Vector3 target)
        {
            agent.SetDestination(target);
            _isActive = true;
        }

        private void Update()
        {
            if (!_isActive) return;

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                OnCompletePathEvent?.Invoke();
                _isActive = false;
            }
            else if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {
                OnFailedPathEvent?.Invoke();
                _isActive = false;
            }
        }
    }
}