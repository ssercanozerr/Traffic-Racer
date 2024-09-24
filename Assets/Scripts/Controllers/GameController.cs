using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform _playerCarPosition;

        [SerializeField] private float _spawnPositionX;
        [SerializeField] private float[] _spawnPositionsY;
        [SerializeField] private float _spawnPositionZ;

        [SerializeField] private float _spawnTime;
        [SerializeField] private float _spawnTimeMin;
        [SerializeField] private float _spawnTimeDependentScore;
        [SerializeField] private float _spawnTimeDecreaseAmount;
        [SerializeField] private float _spawnTimeDependentScoreIncreaseAmount;

        [SerializeField] private GameObject _endPanel;
        [SerializeField] private TextMeshProUGUI _finalScoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;

        private bool _isGamePause;

        private void Start()
        {
            int playerCarIndex = CarSelectionSignal.Instance.getSelectedCarIndex;
            GameObject playerCar = PoolSignal.Instance.onGetObjectFromPool?.Invoke((EntityTypesPlayer)playerCarIndex);

            AudioSource playerAudioSource = playerCar.GetComponent<AudioSource>();
            PlayerBehaviourController playerBehaviourController = playerCar.GetComponent<PlayerBehaviourController>();

            playerAudioSource.enabled = true;
            playerBehaviourController.enabled = true;

            playerCar.transform.position = _playerCarPosition.position;

            StartCoroutine(SpawnCarsWithInterval());
        }

        private IEnumerator SpawnCarsWithInterval()
        {
            while (true)
            {
                if (!GameSignal.Instance.onGetIsGamePause.Invoke())
                {
                    GetRandomCar();
                    yield return new WaitForSeconds(_spawnTime);

                    if (CanvasSignal.Instance.onGetScore?.Invoke() >= _spawnTimeDependentScore && _spawnTime != _spawnTimeMin)
                    {
                        _spawnTime -= _spawnTimeDecreaseAmount;
                        _spawnTimeDependentScore += _spawnTimeDependentScoreIncreaseAmount;
                    }
                }
                else
                {
                    yield return null;
                }
            }
        }

        public void OnGameOver()
        {
            AudioSignal.Instance.onCarIdleSoundStop?.Invoke();
            AudioSignal.Instance.onCarCrashSoundPlay?.Invoke();

            _finalScoreText.text = CanvasSignal.Instance.onGetScore?.Invoke().ToString();
            _bestScoreText.text = CanvasSignal.Instance.onGetBestScore?.Invoke().ToString();
            _endPanel.SetActive(true);
            
            GameSignal.Instance.onGamePause?.Invoke();
        }

        public void OnGamePause()
        {
            _isGamePause = true;
        }

        public void OnGameResume()
        {
            _isGamePause = false;
        }

        public bool OnGetIsGamePause()
        {
            return _isGamePause;
        }

        private GameObject GetRandomCar()
        {
            int carType = Random.Range(2, 10);
            EntityTypesAI selectedCarType = (EntityTypesAI)carType;
            GameObject car = PoolSignal.Instance.onGetObjectFromPool?.Invoke(selectedCarType);
            SetRandomPosition(car);
            return car;
        }

        private void SetRandomPosition(GameObject car)
        {
            float randomLaneY = _spawnPositionsY[Random.Range(0, _spawnPositionsY.Length)];

            car.transform.position = new (_spawnPositionX, randomLaneY, _spawnPositionZ);
        }
    }
}