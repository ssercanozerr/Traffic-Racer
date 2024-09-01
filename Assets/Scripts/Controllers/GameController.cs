using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float _xPosition;
        [SerializeField] private float _yMin;
        [SerializeField] private float _yMax;
        [SerializeField] private float second;

        private void Start()
        {
            StartCoroutine(SpawnCarsWithInterval());
        }

        private IEnumerator SpawnCarsWithInterval()
        {
            while (true)
            {
                GetRandomCar();
                yield return new WaitForSeconds(second);
            }
        }

        private GameObject GetRandomCar()
        {
            int carType = Random.Range(0, 7);
            EntityTypes selectedCarType = (EntityTypes)carType;
            GameObject car = PoolSignal.Instance.onGetObjectFromPool?.Invoke(selectedCarType);
            SetRandomPosition(car);
            return car;
        }

        private void SetRandomPosition(GameObject car)
        {
            car.transform.position = new Vector2(_xPosition, Random.Range(_yMin, _yMax));
        }

    }
}