using System;

namespace Gameplay
{
    public interface IEnemySpawnStrategy
    {
        event Action OnSpawnEnemy;
        void Start();
        void Update();
    }
}