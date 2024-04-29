using UnityEngine;
using UnityEngine.Events;

namespace InteractableEnviroment.Restoraunt.Triggers
{
    public interface IEventable<T>
    {
        UnityEvent<T> OnEnter { get;}
        UnityEvent<T> OnStay{ get;}
        UnityEvent<T> OnExit{ get;}
    }
}