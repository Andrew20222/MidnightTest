using Observer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Menu
{
    public class Controller : BasePanel
    {
        [SerializeField] private Observer.Observer startObserver;
        [SerializeField] private Button playBtn;
        private IObserverCallbackable _callbackable;
        private void Awake()
        {
            _callbackable = startObserver;
        }

        private void Start()
        {
            
            Show();
            playBtn.onClick.AddListener(Play);
        }

        private void Play()
        {
            Hide();
            _callbackable.OnCallback();
        }
    }
}