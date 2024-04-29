using System;
using StorageService;
using StorageService.Json;
using UnityEngine;

namespace Money
{
    public class Controller : MonoBehaviour
    {
        public const string SAVE_KEY = "Money";
        public Data DataMoney { get; private set; }
        
        private IStorageService _storageService;
        private void Awake()
        {
            _storageService = new JsonToFileStorageService();
        }
        
        private void Start()
        {
            _storageService.Load<Data>(SAVE_KEY, (data) =>
            {
                DataMoney = data;
            });
        }

        public void AddMoney(int value)
        {
            DataMoney.Money += value;
            _storageService.Save(SAVE_KEY, DataMoney);
        }
        public void ResetMoney()
        {
            DataMoney.Money = 0;
            _storageService.Save(SAVE_KEY, DataMoney);
        }
    }
}