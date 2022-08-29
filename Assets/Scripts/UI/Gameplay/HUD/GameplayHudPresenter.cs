using Gameplay;
using Gameplay.Components;

namespace UI.Gameplay
{
    public class GameplayHudPresenter
    {
        private readonly IGameplayHudView _view;
        private readonly GameplayHudModel _model;
        
        private readonly PlayerScoreCounterComponent _scoreCounter;
        private readonly PlayerDistanceCounterComponent _distanceCounter;

        public GameplayHudPresenter(IGameplayHudView view, GameplayHudModel model, Player player)
        {
            _view = view;
            _model = model;

            _model.StateChanged += OnModelStateChanged;
            
            _scoreCounter = player.GetComponent<PlayerScoreCounterComponent>();
            _distanceCounter = player.GetComponent<PlayerDistanceCounterComponent>();
        }

        private void OnModelStateChanged()
        {
            RepaintView();
        }

        public void Update()
        {
            _model.Score = _scoreCounter.Score;
            _model.DistancePassed = _distanceCounter.Distance;
        }

        private void RepaintView()
        {
            _view.Score = _model.Score;
            _view.DistancePassed = _model.DistancePassed;
        }

        public void Destroy()
        {
            _model.StateChanged -= OnModelStateChanged;
        }
    }
}
