using System;
using UnityEngine;

namespace Gameplay.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionDetectorComponent : MonoBehaviour
    {
        public event Action<Collider2D> CollisionDetected;

        [SerializeField] private ContactFilter2D _contactFilter;

        private Collider2D _collider;
        private Collider2D[] _collisionResults;
        
        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _collisionResults = new Collider2D[5];
        }

        private void Update()
        {
            var collisions = Physics2D.OverlapCollider(_collider, _contactFilter, _collisionResults);
            var i = collisions;
            while(--i > -1)
            {
                CollisionDetected?.Invoke(_collisionResults[i]);
            }
        }
    }
}
