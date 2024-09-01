using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yMin;
    [SerializeField] private float _yMax;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        _rb.velocity = new (0, _speed * Time.fixedDeltaTime * verticalMovement);

        Vector2 boundaryPosition = _rb.position;
        boundaryPosition.y = Mathf.Clamp(boundaryPosition.y, _yMin, _yMax);
        _rb.position = boundaryPosition;
    }
}
