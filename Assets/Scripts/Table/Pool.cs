using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Table
{
    public class Pool : BasePool<Table>
    {
        [SerializeField] private List<Table> instances;
        private Queue<Table> _free;
        private List<Table> _busy;

        public override void Awake()
        {
            _free = new Queue<Table>();
            _busy = new List<Table>();
            _instances = new Queue<Table>();
            foreach (var instance in instances)
            {
                _instances.Enqueue(instance);
            }
            _free = new(_instances);
        }

        public override Table GetInstance()
        {
            if (TryGet())
            {
                var table = _free.Dequeue();
            
                if (table != null)
                    _busy.Add(table);
                return table;
            }

            return null;
        }

        private bool TryGet()
        {
            if (_free.Count > 0)
            {
                return true;
            }

            return false;
        }

        public override void ReturnInstance(Table value)
        {
            _busy.Remove(value);
            _free.Enqueue(value);
        }

        public void AddTable()
        {
            var instance = AddInstance();
            _free.Enqueue(instance);
            _instances.Enqueue(instance);
        }
    }
}