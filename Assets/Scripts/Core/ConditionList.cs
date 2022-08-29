using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class ConditionList<T> : IEnumerable<T> where T : class
    {
        private readonly List<T> _list;

        public ConditionList()
        {
            _list = new List<T>();
        }
        
        public void Add(IService item)
        {
            if (item is T service)
            {
                _list.Add(service);
            }
        }

        public void ForEach(Action<T> action)
        {
            _list.ForEach(action);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}