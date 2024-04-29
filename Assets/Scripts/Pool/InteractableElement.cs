using UnityEngine;

namespace Pool
{
    public abstract class InteractableElement : Element
    {
        public abstract void SetObserver(Observer.Observer interactableObserver);
    }
}