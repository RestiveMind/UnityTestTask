using System;
using Core;
using Gameplay.Input;
using Gameplay.ObjectFactory;
using Gameplay.Storage;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class GameplayService : IGameplayService, IUpdatable, IDisposable
    {
        private const int EnemySpawnBounds = 5;

        private Enemy _enemyPrefab;
        private readonly IObjectFactoryService _objectFactory;
        private IEnemySpawnStrategy _enemySpawnStrategy;

        public Player Player { get; private set; }

        public GameplayService(IObjectFactoryService objectFactory)
        {
            _objectFactory = objectFactory;
        }

        public void StartLevel(LevelParams levelParams, IEnemySpawnStrategy enemySpawnStrategy)
        {
            _enemySpawnStrategy = enemySpawnStrategy;
            _enemyPrefab = levelParams.EnemyPrefab;

            Player = _objectFactory.CreateObject(levelParams.PlayerPrefab);

            _enemySpawnStrategy.Start();
            _enemySpawnStrategy.OnSpawnEnemy += OnEnemySpawnHandler;
        }

        private void OnEnemySpawnHandler()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var randomPosition = new Vector2(
                Random.Range(-EnemySpawnBounds, EnemySpawnBounds),
                Random.Range(-EnemySpawnBounds, EnemySpawnBounds));

            var enemy = _objectFactory.CreateObject(_enemyPrefab);
            enemy.transform.SetPositionAndRotation(randomPosition, Quaternion.identity);
        }

        public void Update()
        {
            _enemySpawnStrategy.Update();
        }

        public void Dispose()
        {
            _enemySpawnStrategy.OnSpawnEnemy -= OnEnemySpawnHandler;
        }
    }
}
