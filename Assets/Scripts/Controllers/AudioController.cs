using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _carIdleSound;
        [SerializeField] private AudioSource _carCrashSound;

        public void OnCarCrashSoundPlay()
        {
            _carCrashSound.Play();
        }

        public void OnCarIdleSoundStop()
        {
            _carIdleSound.Stop();
        }
    }
}