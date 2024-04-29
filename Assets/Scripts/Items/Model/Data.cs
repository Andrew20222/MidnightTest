using System;
using UnityEngine;

namespace Items.Model
{
    [Serializable]
    public class Data
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField, Range(0,50)] public int Price { get; private set; }
        
    }
}


