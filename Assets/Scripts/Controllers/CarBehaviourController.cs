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
            _rb.velocity = _speed * Time.fixedDeltaTime * Vector3.left;
        }
    }
}