using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class GameSignal : MonoBehaviour
    {
        public static GameSignal Instance;

        public UnityAction onGameOver;

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