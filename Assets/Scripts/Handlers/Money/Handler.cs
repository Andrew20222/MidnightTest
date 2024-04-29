using System;
using InteractableEnviroment.Restoraunt.Handlers;
using Money;
using Observer;
using Unit;
using UnityEngine;
using Controller = Money.Controller;

namespace Handlers.Money
{
    public class Handler : MonoBehaviour
    {
        [SerializeField] private Controller controller;
        [SerializeField] private View view;
        
        public void UpdateMoney(IClient client)
        {
            controller.AddMoney(client.Item.Price);
            view.UpdateMoney(controller.DataMoney);
        }
        public void UpdateMoney()
        {
            view.UpdateMoney(controller.DataMoney);
        }
        public void ResetMoney()
        {
            controller.ResetMoney();
        }
    }
}