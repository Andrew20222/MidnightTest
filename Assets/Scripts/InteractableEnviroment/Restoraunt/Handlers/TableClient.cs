using Unit;
using UnityEngine;

namespace InteractableEnviroment.Restoraunt.Handlers
{
    public class TableClient : MonoBehaviour
    {
        [SerializeField] private Table.Table table;
        public IClient Client { get; private set; }

        public void ShowOrder(IClient client)
        {
            Client = client;
            table.View.SetIcon(client.Item.Icon);
            table.View.Show();
        }

        public void HideOrder(IClient client)
        {
            table.View.Hide();
        }
    }
}