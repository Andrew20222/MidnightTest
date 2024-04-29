using System;
using UnityEngine;
using UnityEngine.AI;

namespace Unit.Player
{
    public class Movement : MonoBehaviour, IMovable
    {
        public event Action OnCompletePathEvent;
        public event Action OnFailedPathEvent;

        [SerializeField] private NavMeshAgent agent;

        public void Move(Vector3 target) => 
            agent.SetDestination(target);
    }
}

