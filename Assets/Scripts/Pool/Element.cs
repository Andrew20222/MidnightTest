using System;
using UI;
using UnityEngine;

namespace Pool
{
    public abstract partial class Element : MonoBehaviour
    {
        public event Action<Element> ReturnInPool;
        protected bool _isReturned;

        public virtual void Init()
        {
            if (!_isReturned) return;
            _isReturned = false;
        }

        public virtual void Finalize()
        {
            if (_isReturned) return;
            ReturnInPool?.Invoke(this);
            _isReturned = true;
        }

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public virtual void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}