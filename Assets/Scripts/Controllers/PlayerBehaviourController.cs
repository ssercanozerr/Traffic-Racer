using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yMin;
    [SerializeField] private float _yMax;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        _rb.velocity = new (0, _speed * Time.fixedDeltaTime * verticalMovement, 0);

        Vector3 boundaryPosition = _rb.position;
        boundaryPosition.y = Mathf.Clamp(boundaryPosition.y, _yMin, _yMax);
        _rb.position = boundaryPosition;
    }
}
