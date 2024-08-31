using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");

        _rb.velocity = new (0, _speed * Time.fixedDeltaTime * verticalMovement);
    }
}
