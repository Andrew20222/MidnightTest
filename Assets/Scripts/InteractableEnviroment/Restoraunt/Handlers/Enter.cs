using Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractableEnviroment.Restoraunt.Handlers
{
    public class Enter : MonoBehaviour
    {
        [SerializeField] private Table.Pool tablePool;
        [SerializeField] private Items.SO.Items items;
        
        public void SetTarget(IClient client)
        {
            var table = tablePool.GetInstance();
            if(table != null)
                client.SetTarget(table.transform);
        }

        public void SitDown(IClient client)
        {
            client.SitDown();
        }

        public void SetItem(IClient client)
        {
            var item = items.ItemsData[Random.Range(0, items.ItemsData.Length)];
            client.SetItem(item);
        }
    }
}

