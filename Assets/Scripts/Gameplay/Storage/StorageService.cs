using System;
using UnityEngine;

namespace Gameplay.Storage
{
    public class StorageService : IStorageService, IDisposable
    {
        private const string ScoreKey = "score";
        private const string DistancePassedKey = "distance-passed";

        public float GetScore()
        {
            return PlayerPrefs.GetFloat(ScoreKey, 0);
        }

        public void SetScore(float value)
        {
            PlayerPrefs.SetFloat(ScoreKey, value);
        }

        public float GetDistancePassed()
        {
            return PlayerPrefs.GetFloat(DistancePassedKey, 0);
        }

        public void SetDistancePassed(float value)
        {
            PlayerPrefs.SetFloat(DistancePassedKey, value);
        }

        private void Save()
        {
            PlayerPrefs.Save();
        }

        public void Dispose()
        {
            Save();
        }
    }
}
