using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay
{
    public class GameplayHudView : MonoBehaviour, IGameplayHudView
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _distancePassedText;

        public float Score
        {
            set => _scoreText.text = $"Score: {value:F0}";
        }

        public float DistancePassed
        {
            set => _distancePassedText.text = $"Distance passed: {value:F0}";
        }
    }
}
