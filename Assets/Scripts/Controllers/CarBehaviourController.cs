using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CarBehaviourController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _speed * Time.fixedDeltaTime * Vector2.left;
        }
    }
}