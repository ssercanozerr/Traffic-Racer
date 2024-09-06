using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioController _audioController;

        private void OnEnable()
        {
            AudioSignal.Instance.onCarCrashSoundPlay += _audioController.OnCarCrashSoundPlay;
            AudioSignal.Instance.onCarIdleSoundStop += _audioController.OnCarIdleSoundStop;
        }

        private void OnDisable()
        {
            AudioSignal.Instance.onCarCrashSoundPlay -= _audioController.OnCarCrashSoundPlay;
            AudioSignal.Instance.onCarIdleSoundStop -= _audioController.OnCarIdleSoundStop;
        }
    }
}