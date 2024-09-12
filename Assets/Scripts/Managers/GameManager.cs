using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;

        private void OnEnable()
        {
            GameSignal.Instance.onGameOver += _gameController.OnGameOver;
            GameSignal.Instance.onGamePause += _gameController.OnGamePause;
            GameSignal.Instance.onGameResume += _gameController.OnGameResume;
            GameSignal.Instance.onGetIsGamePause += _gameController.OnGetIsGamePause;
        }

        private void OnDisable()
        {
            GameSignal.Instance.onGameOver -= _gameController.OnGameOver;
            GameSignal.Instance.onGamePause -= _gameController.OnGamePause;
            GameSignal.Instance.onGameResume -= _gameController.OnGameResume;
            GameSignal.Instance.onGetIsGamePause -= _gameController.OnGetIsGamePause;
        }

    }
}