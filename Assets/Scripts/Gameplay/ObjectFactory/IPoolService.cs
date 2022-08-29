using Core;
using UnityEngine;

namespace Gameplay.ObjectFactory
{
    public interface IPoolService : IService
    {
        T Get<T>(T objectPrefab) where T : MonoBehaviour;
    }
}