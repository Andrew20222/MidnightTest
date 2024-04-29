using System;
using System.Collections.Generic;
using Observer;
using UnityEngine;

namespace Pool
{
    public abstract class BasePool<T> : MonoBehaviour where T : Element
    {
        [SerializeField] protected T prefab;
        [SerializeField] protected Transform parent;
        [SerializeField] private int awakeCount;
        [SerializeField] protected Observer.Observer startObserver;
        [SerializeField] protected Observer.Observer interactableObserver;
        private IObserverListenable _listenableInteractable;
        private IObserverListenable _listenableStart;
        protected Queue<T> _instances;

        public virtual void Awake()
        {
            _listenableInteractable = interactableObserver;
            _listenableStart = startObserver;
            _instances = new Queue<T>();

            _listenableInteractable.Subscribe(() => AddInstance());

            _listenableStart.Subscribe(() =>
            {
                for (int i = 0; i < awakeCount; i++)
                {
                    _instances.Enqueue(AddInstance());
                }
            });
        }

        protected virtual T AddInstance()
        {
            var instance = Instantiate(prefab,parent);
            instance.Init();
            instance.ReturnInPool += (_) => ReturnInstance(instance);
            return instance;
        }

        public virtual T GetInstance()
        {
            if (_instances.Count == 0) 
            {
                _instances.Enqueue(AddInstance());
            }
    
            return _instances.Dequeue();
        }

        public virtual void ReturnInstance(T value)
        {
            _instances.Enqueue(value);
        }
    }
}