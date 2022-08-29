using Gameplay.ObjectFactory;
using Gameplay.Storage;
using UnityEngine;

namespace Gameplay.Components
{
    [RequireComponent(typeof(DamageDealerComponent))]
    public class PlayerScoreCounterComponent : MonoBehaviour
    {
        [SInject] private readonly IStorageService _storage = null;
        
        private DamageDealerComponent _damageDealer;
        private float _currentScore;
        
        public float Score => _currentScore;

        private void Awake()
        {
            _damageDealer = GetComponent<DamageDealerComponent>();
            _damageDealer.DamageDealt += OnDamageDealt;
        }

        private void Start()
        {
            _currentScore = _storage.GetScore();
        }

        private void OnDamageDealt()
        {
            _currentScore += 100;
            _storage.SetScore(_currentScore);
        }

        private void OnDestroy()
        {
            _damageDealer.DamageDealt -= OnDamageDealt;
        }
    }
}