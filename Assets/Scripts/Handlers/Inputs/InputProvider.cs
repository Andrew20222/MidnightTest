using System;
using UnityEngine;

namespace Handles.Inputs
{
    public class InputProvider : MonoBehaviour
    {
        public event Action<Vector3> ClickMouseEvent;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    ClickMouseEvent?.Invoke(hit.point);
                }
            }
        }
    }
}

