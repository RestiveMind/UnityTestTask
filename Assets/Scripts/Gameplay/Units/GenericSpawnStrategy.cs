using System;
using UnityEngine;
using Utils;

namespace Gameplay
{
    public class GenericSpawnStrategy : IEnemySpawnStrategy
    {
        private const float EnemySpawnInterval = 1.0f;
        private const int MaxEnemiesCount = 10;
        
        private float _enemySpawnTimer;
        
        public event Action OnSpawnEnemy;

        public void Start()
        {
            _enemySpawnTimer = Time.time;
        }

        public void Update()
        {
            if(TimerHelper.PassedSince(EnemySpawnInterval, _enemySpawnTimer))
            {
                if(Enemy.Count < MaxEnemiesCount)
                {
                    OnSpawnEnemy?.Invoke();
                }
                _enemySpawnTimer = Time.time;
            }
        }
    }
}