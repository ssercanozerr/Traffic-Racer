using Assets.Scripts.Enums;
using UnityEngine;
using System;
using Assets.Scripts.Signals;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class CarSelectionController : MonoBehaviour
    {
        [SerializeField] private Transform _carTransform_1;
        [SerializeField] private Transform _carTransform_2;
        [SerializeField] private GameObject _platform;
        [SerializeField] private GameObject _selectButton;
        [SerializeField] private GameObject _lockIcon;
        [SerializeField] private int _minScore;

        private int _selectedCarIndex = 0;
        private GameObject _currentCar;
        private Transform _carTransform;
        private Color _disabledColor = Color.gray;
        private Color _enabledColor = new (0f, 0.647f, 0.012f);

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
            if (_currentCar != null) { _currentCar.SetActive(false); }

            _currentCar = PoolSignal.Instance.onGetObjectFromPool?.Invoke((EntityTypesPlayer)index);

            if (index == 0) 
            { 
                _carTransform = _carTransform_1; 
                _carTransform.localScale = _carTransform_1.localScale;
            }
            else 
            { 
                _carTransform = _carTransform_2;
                _carTransform.localScale = _carTransform_2.localScale;
            }

            _currentCar.transform.SetParent(_platform.transform, true);
            _currentCar.transform.localScale = _carTransform.localScale;
            _currentCar.transform.SetPositionAndRotation(_carTransform.position, _carTransform.rotation);

            if (index == 1 && PlayerPrefs.GetInt("BestScore", 0) < _minScore) { CarLockControl(true, _disabledColor); }
            else { CarLockControl(false, _enabledColor); }

            CarSelectionSignal.Instance.getSelectedCarIndex = index;
        }

        private void CarLockControl(bool boolean, Color color)
        {
            _lockIcon.SetActive(boolean);
            _selectButton.GetComponent<Button>().interactable = !boolean;
            _selectButton.GetComponent<Image>().color = color;
        }
    }
}