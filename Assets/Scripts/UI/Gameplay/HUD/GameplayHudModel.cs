using System;

namespace UI.Gameplay
{
    public class GameplayHudModel
    {
        public event Action StateChanged;
        
        private float _score;
        private float _distancePassed;

        public float Score
        {
            get => _score;
            set
            {
                if (value != _score)
                {
                    _score = value;
                    StateChanged?.Invoke();
                }
            }
        }

        public float DistancePassed
        {
            get => _distancePassed;
            set
            {
                if (value != _distancePassed)
                {
                    _distancePassed = value;
                    StateChanged?.Invoke();
                }
            }
        }
    }
}