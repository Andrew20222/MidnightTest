using System;
using UnityEngine;

namespace Unit
{
    public interface IMovable
    {
        event Action OnCompletePathEvent;
        event Action OnFailedPathEvent;
        void Move(Vector3 target);
    }
}