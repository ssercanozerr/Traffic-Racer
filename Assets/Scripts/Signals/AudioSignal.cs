using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class AudioSignal : MonoBehaviour
    {
        public static AudioSignal Instance;

        public UnityAction onCarCrashSoundPlay;
        public UnityAction onCarIdleSoundStop;

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