using Items.Model;
using UnityEngine;

namespace Unit
{
    public interface IClient
    {
        Data Item { get; }
        void SetTarget(Transform target);
        void SitDown();
        void SetItem(Data item);
    }
}