using System.Collections;
using Money;
using Observer;
using Unit;
using Unit.Client;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableEnviroment.Restoraunt.Handlers
{
    public class TablePlayer : MonoBehaviour
    {
        public UnityEvent<IClient> OnApplyItem;

        [SerializeField] private Observer.Observer interactable;
        [SerializeField] private TableClient table;
        [SerializeField] private Transform startPos;
        [SerializeField] private float delay = 2f;
        private IObserverCallbackable _callbackable;
        private Coroutine _coroutine;
        private void Start()
        {
            _callbackable = interactable;
        }

        public void StartApplyItem(IInteractable player)
        {
            _coroutine = StartCoroutine(ApplyItem());
        }
        public void StopApplyItem(IInteractable player)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
        public void SetTarget(IClient client)
        {
            client.SetTarget(startPos);
        }
        private IEnumerator ApplyItem()
        {
            yield return new WaitForSeconds(delay);
            OnApplyItem?.Invoke(table.Client);
            _callbackable.OnCallback();
        }
    }
}