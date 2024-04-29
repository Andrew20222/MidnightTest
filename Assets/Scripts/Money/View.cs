using TMPro;
using UnityEngine;

namespace Money
{
    public class View : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI money;

        public void UpdateMoney(Data data)
        {
            money.text = $"Money {data.Money}$";
        }
    }
}