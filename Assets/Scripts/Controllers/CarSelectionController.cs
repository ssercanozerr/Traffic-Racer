using Assets.Scripts.Enums;
using UnityEngine;
using System;
using Assets.Scripts.Signals;

namespace Assets.Scripts.Controllers
{
    public class CarSelectionController : MonoBehaviour
    {
        [SerializeField] private Transform _carPosition_1;
        [SerializeField] private Transform _carPosition_2;
        [SerializeField] private GameObject _platform;

        private int _selectedCarIndex = 0;
        private GameObject _currentCar;
        private Transform carPosition;

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

        private void ShowCar(int index)
        {
            if (_currentCar != null)
            {
                _currentCar.SetActive(false);
            }

            _currentCar = PoolSignal.Instance.onGetObjectFromPool?.Invoke((EntityTypesPlayer)index);

            if (_selectedCarIndex == 0) { carPosition = _carPosition_1; }
            else { carPosition =  _carPosition_2; }
                
            _currentCar.transform.SetPositionAndRotation(carPosition.position, carPosition.rotation);
            _currentCar.transform.SetParent(_platform.transform, true);
            CarSelectionSignal.Instance.getSelectedCarIndex = index;
        }
    }
}