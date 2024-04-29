using System;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableEnviroment.Restoraunt.Triggers
{
    
    public abstract class BaseTrigger<T> : MonoBehaviour, IEventable<T>
    {
        [field:SerializeField] public UnityEvent<T> OnEnter { get; private set; }
        [field:SerializeField] public UnityEvent<T> OnStay { get; private set;}
        [field:SerializeField] public UnityEvent<T> OnExit { get; private set;}

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T component))
            {
                OnEnter?.Invoke(component);
            }
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out T component))
            {
                OnStay?.Invoke(component);
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T component))
            {
                OnExit?.Invoke(component);
            }
        }
    }
}