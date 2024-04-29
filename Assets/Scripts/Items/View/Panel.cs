using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Items.View
{
    public class Panel : BasePanel
    {
        [SerializeField] private Image icon;

        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }
    }
}