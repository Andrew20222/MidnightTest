using Handles.Inputs;
using Items.Model;
using Observer;
using Unit.Client;
using UnityEngine;

namespace Unit.Player
{
    public class Controller : MonoBehaviour, IInteractable
    {
        [SerializeField] private Observer.Observer startObserver;
        [SerializeField] private InputProvider inputProvider;
        [SerializeField] private Movement movement;
        private IObserverListenable _listenable;
        private Data _item;

        private void Start()
        {
            _listenable = startObserver;
            _listenable.Subscribe(SubscribeInput);
        }
        private void SubscribeInput() => 
            inputProvider.ClickMouseEvent += movement.Move;

        public void SetItem(Data item) => 
            _item = item;
    }
}