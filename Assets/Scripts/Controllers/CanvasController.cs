using Assets.Scripts.Signals;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private int _scorePerSecond;

        private float _score;
        private float _timeElapsed;

        private void Update()
        {
            if (!GameSignal.Instance.onGetIsGamePause.Invoke())
            {
                UpdateScore();
            }
        }

        private void UpdateScore()
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed >= 1f)
            {
                _score += _scorePerSecond;
                _timeElapsed = 0f;

                _scoreText.text = _score.ToString();
            }
        }

        public float OnGetScore()
        {
            return _score;
        }
    }
}