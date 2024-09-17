using Assets.Scripts.Enums;
using UnityEngine;
using System;
using Assets.Scripts.Signals;

namespace Assets.Scripts.Controllers
{
    public class CarSelectionController : MonoBehaviour
    {
        [SerializeField] private Transform _carPosition;

        private int _selectedCarIndex = 0;
        private GameObject _currentCar;

        private void Start()
        {
            ShowCar(_selectedCarIndex);
        }

        public void NextCar()
        {
            _selectedCarIndex++;
            if (_selectedCarIndex >= Enum.GetValues(typeof(EntityTypesPlayer)).Length)
            {
                _selectedCarIndex = 0;
            }
            ShowCar(_selectedCarIndex);
        }

        public void PreviousCar()
        {
            _selectedCarIndex--;
            if (_selectedCarIndex < 0)
            {
                _selectedCarIndex = Enum.GetValues(typeof(EntityTypesPlayer)).Length - 1;
            }
            ShowCar(_selectedCarIndex);
        }

        public GameObject OnGetSelectedCar()
        {
            return _currentCar;
        }

        private void ShowCar(int index)
        {
            if (_currentCar != null)
            {
                _currentCar.SetActive(false);
            }

            _currentCar = PoolSignal.Instance.onGetObjectFromPool?.Invoke((EntityTypesPlayer)index);
            if (_currentCar != null)
            {
                _currentCar.transform.position = _carPosition.position;
            }
        }
    }
}