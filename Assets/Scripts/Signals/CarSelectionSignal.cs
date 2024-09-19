using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class CarSelectionSignal : MonoBehaviour
    {
        public static CarSelectionSignal Instance;

        public int getSelectedCarIndex;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}