using System;
using UnityEngine;

namespace Gameplay.Components
{
    [RequireComponent(typeof(CollisionDetectorComponent))]
    public class DamageDealerComponent : MonoBehaviour
    {
        public event Action DamageDealt;
        
        private CollisionDetectorComponent _collisionDetector;

        private void Awake()
        {
            _collisionDetector = GetComponent<CollisionDetectorComponent>();
            _collisionDetector.CollisionDetected += OnCollisionDetected;
        }

        private void OnCollisionDetected(Collider2D otherCollider)
        {
            var damageReceiver = otherCollider.gameObject.GetComponent<DamageReceiverComponent>();
            if (damageReceiver)
            {
                damageReceiver.ReceiveDamage();
            }
            
            DamageDealt?.Invoke();
        }

        private void OnDestroy()
        {
            _collisionDetector.CollisionDetected -= OnCollisionDetected;
        }
    }
}
