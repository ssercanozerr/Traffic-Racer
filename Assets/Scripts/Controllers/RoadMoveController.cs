using UnityEngine;

public class RoadMoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _loopStartPosition;
    [SerializeField] private float _loopEndPosition;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _speed * Time.fixedDeltaTime * Vector2.left;

        if (_rb.position.x < _loopEndPosition)
        {
            Vector2 loopPosition = _rb.position;
            loopPosition.x = _loopStartPosition;
            _rb.position = loopPosition;
        }
    }
}
