using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score;

        public void OnUpdateScore(int score)
        {
            _score += score;
            _scoreText.text = _score.ToString();
        }

        public int OnGetScore()
        {
            return _score;
        }
    }
}