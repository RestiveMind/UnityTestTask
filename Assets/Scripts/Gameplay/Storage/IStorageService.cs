using Core;

namespace Gameplay.Storage
{
    public interface IStorageService : IService
    {
        float GetScore();
        void SetScore(float value);
        float GetDistancePassed();
        void SetDistancePassed(float value);
    }
}
