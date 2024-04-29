using Items.View;
using Pool;
using UnityEngine;

namespace Table
{
    public class Table : Element
    {
        [field:SerializeField] public Panel View { get; private set; }
        [field:SerializeField] public Transform PointView { get; private set; }

        public void SetPanel(Panel view)
        {
            View = view;
        }
    }
}