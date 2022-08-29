using Core;

namespace Gameplay
{
    public interface IGameplayService : IService
    {
        Player Player { get; }
        void StartLevel(LevelParams levelParams, IEnemySpawnStrategy enemySpawnStrategy);
    }
}
