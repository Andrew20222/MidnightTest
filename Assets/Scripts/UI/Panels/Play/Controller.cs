using Handlers.Money;
using Money;
using Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels.Play
{
    public class Controller : BasePanel
    {
        [SerializeField] private Observer.Observer startObserver;
        [SerializeField] private Handler money;
        [SerializeField] private Button resetBtn;
        private IObserverListenable _listanable;

        private void Start()
        {
            _listanable = startObserver;
            _listanable.Subscribe(Play);
            resetBtn.onClick.AddListener(ResetClick);
        }
        private void Play()
        {
            Show();
            money.UpdateMoney();
        }
        private void ResetClick()
        {
            money.ResetMoney();
            money.UpdateMoney();
        }
    }
}

