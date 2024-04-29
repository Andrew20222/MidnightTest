using System;
using System.Collections.Generic;
using Items.View;
using UnityEngine;

namespace UI
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private List<Table.Table> tables;
        [SerializeField] private Panel prefab;

        private void Awake()
        {
            foreach (var table in tables)
            {
                var instance = Instantiate(prefab,table.PointView.position,
                    Quaternion.identity, transform);
                table.SetPanel(instance);
            }
        }
    }
}