using UnityEngine;

namespace Gameplay
{
    public class LevelParams : ScriptableObject
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Enemy _enemyPrefab;

        public Enemy EnemyPrefab => _enemyPrefab;

        public Player PlayerPrefab => _playerPrefab;
    }
}