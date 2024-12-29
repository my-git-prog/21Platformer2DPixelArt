using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpPower = 8f;
    [SerializeField] private Controller _controller;
    [SerializeField] private FloorSensor _floorSensor;

    private Rigidbody2D _rigidbody;
    private LandingState _landingState = LandingState.OnFloor;

   private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controller.Moving += Move;
        _controller.Jumping += Jump;
        _floorSensor.Landing += Land;
        _floorSensor.Flying += Fly;
    }

    private void OnDisable()
    {
        _controller.Moving -= Move;
        _controller.Jumping -= Jump;
        _floorSensor.Landing -= Land;
        _floorSensor.Flying -= Fly;
    }

    private void Jump()
    {
        if (_landingState != LandingState.InAir)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Move(float horizontal)
    {
        transform.Translate(Vector2.right * horizontal * _speed * Time.deltaTime);
    }

    private void Land()
    {
        _landingState = LandingState.OnFloor;
    }

    private void Fly()
    {
        _landingState = LandingState.InAir;
    }    
}