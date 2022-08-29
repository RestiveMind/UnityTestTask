using Gameplay.ObjectFactory;
using Gameplay.Storage;
using UnityEngine;

namespace Gameplay.Components
{
    public class PlayerDistanceCounterComponent : MonoBehaviour
    {
        [SInject] private readonly IStorageService _storage = null;
        
        private Vector3 _currentPosition;
        private float _distancePassed;
        
        public float Distance => _distancePassed;

        private void Start()
        {
            _currentPosition = transform.position;
            _distancePassed = _storage.GetDistancePassed();
        }
        private void Update()
        {
            if (!_currentPosition.Equals(transform.position))
            {
                var position = transform.position;
                
                var deltaDistance = (position - _currentPosition).magnitude;
                _distancePassed += deltaDistance;
                _storage.SetDistancePassed(_distancePassed);
                
                _currentPosition = position;
            }
        }
    }
}