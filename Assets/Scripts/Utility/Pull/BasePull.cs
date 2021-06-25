using System.Collections.Generic;
using UnityEngine;

namespace Utility.Pull
{
    public abstract class BasePull<TComponent> : IPull<TComponent> where TComponent : BasePullObject
    {
        private readonly Queue<TComponent> _queue = new Queue<TComponent>();
        private IPullContainer _container;
        private IPull<TComponent> _pullImplementation;

        public virtual void Init(IPullContainer container)
        {
            _container = container;
            for (var i = 1; i <= _container.GetStartCount(); i++)
            {
                var go = Object.Instantiate(_container.GetPrefab(), _container.GetParent());
                _queue.Enqueue(go.GetComponent<TComponent>());
            }
        }

        public virtual void Dispose()
        {
            for (var i = 0; i < _queue.Count; i++) Object.Destroy(_queue.Dequeue().gameObject);
        }

        public TComponent Get()
        {
            if (_queue.Count == 0)
            {
                var go = Object.Instantiate(_container.GetPrefab(), _container.GetParent());
                _queue.Enqueue(go.GetComponent<TComponent>());
            }

            var pullObject = _queue.Dequeue();
            pullObject.Show();
            return pullObject;
        }

        public virtual void Put(TComponent component)
        {
            component.Hide();
            component.transform.SetParent(_container.GetParent(), false);
            _queue.Enqueue(component);
        }
    }
}