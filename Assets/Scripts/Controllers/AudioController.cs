using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _carCrashSound;

        private AudioSource _carIdleSound;

        private void Start()
        {
            _carIdleSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
            if (_carIdleSound == null)
            {
                Debug.Log("asdasdasd");
            }
        }

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