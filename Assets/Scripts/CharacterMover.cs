using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 8f;

    private Rigidbody2D _rigidbody;

   private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_floorSensor.OnFloor)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    public void Move(float horizontal)
    {
        transform.Translate(Vector2.right * horizontal * _speed * Time.deltaTime);
    }
}