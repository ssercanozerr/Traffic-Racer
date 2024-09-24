using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class CanvasSignal : MonoBehaviour
    {
        public static CanvasSignal Instance;

        public Func<int> onGetScore;
        public Func<int> onGetBestScore;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}