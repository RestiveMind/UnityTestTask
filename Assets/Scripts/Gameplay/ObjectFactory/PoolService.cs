using UnityEngine;

namespace Gameplay.ObjectFactory
{
    public class PoolService : IPoolService
    {
        public T Get<T>(T objectPrefab) where T : MonoBehaviour
        {
            return Object.Instantiate(objectPrefab);
        }
    }
}