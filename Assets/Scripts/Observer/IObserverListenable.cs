using System;

namespace Observer
{
    public interface IObserverListenable
    {
        void Subscribe(Action value);
        void Unsubscribe(Action value);
    }
}