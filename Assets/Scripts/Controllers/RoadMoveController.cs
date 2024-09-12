using Assets.Scripts.Signals;
using UnityEngine;

public class RoadMoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _loopStartPosition;
    [SerializeField] private float _loopEndPosition;

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

            if (_rb.position.x < _loopEndPosition)
            {
                Vector3 loopPosition = _rb.position;
                loopPosition.x = _loopStartPosition;
                _rb.position = loopPosition;
            }
        }
        else 
        {
            _rb.isKinematic = true;
        }
    }
}
