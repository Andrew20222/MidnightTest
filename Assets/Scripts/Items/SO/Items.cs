using Items.Model;
using UnityEngine;

namespace Items.SO
{
    [CreateAssetMenu(fileName = "Items", menuName = "ItemsSO/Items", order = 1)]
    public class Items : ScriptableObject
    {
        [field: SerializeField] public Data[] ItemsData { get; private set; }
    }
}