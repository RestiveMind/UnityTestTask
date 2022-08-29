using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public class ServiceController : MonoBehaviour, IServiceProvider
    {
        private List<IService> _allServices;
        private ConditionList<IUpdatable> _updatables;
        private ConditionList<IFixedUpdatable> _fixedUpdatables;
        private ConditionList<IDisposable> _disposables;

        private void Awake()
        {
            _allServices = new List<IService>();
            _updatables = new ConditionList<IUpdatable>();
            _fixedUpdatables = new ConditionList<IFixedUpdatable>();
            _disposables = new ConditionList<IDisposable>();
            
            DontDestroyOnLoad(gameObject);
        }
        
        public T AddService<T>(T service) where T : IService
        {
            _allServices.Add(service);
            _updatables.Add(service);
            _fixedUpdatables.Add(service);
            _disposables.Add(service);

            return service;
        }

        public T GetService<T>() where T : IService
        {
            var service = GetService(typeof(T));
            return (T)service;
        }

        public IService GetService(Type serviceType)
        {
            int i = _allServices.Count;
            while (--i > -1)
            {
                if (serviceType.IsInstanceOfType(_allServices[i]))
                {
                    return _allServices[i];
                }
            }
            
            throw new Exception("Service not found");
        }

        private void Update()
        {
            _updatables.ForEach(service => service.Update());
        }

        private void FixedUpdate()
        {
            _fixedUpdatables.ForEach(service => service.FixedUpdate());
        }

        private void OnDestroy()
        {
            _disposables.ForEach(service => service.Dispose());
        }
    }
}