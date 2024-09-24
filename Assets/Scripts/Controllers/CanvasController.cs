using Assets.Scripts.Signals;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private int _scorePerSecond;

        private int _score;
        private float _timeElapsed;

        private void Update()
        {
            if (!GameSignal.Instance.onGetIsGamePause.Invoke())
            {
                UpdateScore();
            }
        }

        public int OnGetScore()
        {
            return _score;
        }

        public int OnGetBestScore()
        {
            int bestScore = PlayerPrefs.GetInt("BestScore", 0);

            if (_score > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", _score);
                PlayerPrefs.Save();
            }

            return PlayerPrefs.GetInt("BestScore", 0);
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
    }
}