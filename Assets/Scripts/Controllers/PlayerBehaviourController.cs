using Assets.Scripts.Signals;
using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yMin;
    [SerializeField] private float _yMax;
    [SerializeField] private float _smoothTime;

    private Rigidbody _rb;
    private float _currentVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!GameSignal.Instance.onGetIsGamePause.Invoke()) 
        {
            _rb.isKinematic = false;
            float verticalMovement = Input.GetAxis("Vertical");
            float targetPositionY = Mathf.Clamp(_rb.position.y + verticalMovement * _speed * Time.fixedDeltaTime, _yMin, _yMax);
            float newTargetPositionY = Mathf.SmoothDamp(_rb.position.y, targetPositionY, ref _currentVelocity, _smoothTime);

            _rb.MovePosition(new Vector3(_rb.position.x, newTargetPositionY, _rb.position.z));
        }
        else
        {
            _rb.isKinematic = true;
        }
    }
}
