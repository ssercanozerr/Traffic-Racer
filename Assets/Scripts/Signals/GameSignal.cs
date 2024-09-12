using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class GameSignal : MonoBehaviour
    {
        public static GameSignal Instance;

        public UnityAction onGameOver;
        public UnityAction onGamePause;
        public UnityAction onGameResume;
        public Func<bool> onGetIsGamePause = delegate { return false; };

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