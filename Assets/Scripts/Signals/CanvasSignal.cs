using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CanvasSignal : MonoBehaviour
    {
        public static CanvasSignal Instance;

        public UnityAction<int> onUpdateScore;
        public Func<int> onGetScore;

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