using Core;
using UnityEngine;

namespace Gameplay.ObjectFactory
{
    public interface IObjectFactoryService : IService
    {
        T CreateObject<T>(T objectPrefab) where T : MonoBehaviour;
    }
}