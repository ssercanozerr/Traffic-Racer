using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CarBehaviourController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!GameSignal.Instance.onGetIsGamePause.Invoke())
            {
                _rb.isKinematic = false;
                _rb.velocity = _speed * Time.fixedDeltaTime * Vector3.left;
            } 
            else 
            {
                _rb.isKinematic = true;
            }
        }
    }
}