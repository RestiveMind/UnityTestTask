using System;
using System.Linq;
using System.Reflection;
using Core;
using UnityEngine;
using IServiceProvider = Core.IServiceProvider;
using Object = UnityEngine.Object;

namespace Gameplay.ObjectFactory
{
    public class SInjectAttribute : Attribute { }
    
    public class ObjectFactoryService : IObjectFactoryService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPoolService _poolService;
        
        public ObjectFactoryService(IServiceProvider serviceProvider, IPoolService poolService)
        {
            _serviceProvider = serviceProvider;
            _poolService = poolService;
        }

        public T CreateObject<T>(T objectPrefab) where T : MonoBehaviour
        {
            var objectInstance = _poolService.Get(objectPrefab);
            var allComponents = objectInstance.GetComponents<MonoBehaviour>();

            foreach (var component in allComponents)
            {
                var fields = component.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(field => Attribute.IsDefined(field, typeof(SInjectAttribute)));

                foreach (var field in fields)
                {
                    if (field.FieldType.GetInterface(nameof(IService)) != null)
                    {
                        field.SetValue(component, _serviceProvider.GetService(field.FieldType));
                    }
                }
            }

            return objectInstance;
        }
    }
}