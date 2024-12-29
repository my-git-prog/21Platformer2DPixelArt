using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string ParameterIsFlying = "IsFlying";
    private const string ParameterIsMoving = "IsMoving";

    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private Controller _controller;
    [SerializeField] private DirectionState _directionState = DirectionState.Right;
    [SerializeField] private float _stopTime = 0.2f;

    private Animator _animator;
    private float _lastMoveTime = 0f;
    private MoveState _moveState = MoveState.Idle;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _floorSensor.Landing += Land;
        _floorSensor.Flying += Fly;
        _controller.Moving += Move;
    }

    private void OnDisable()
    {
        _floorSensor.Landing -= Land;
        _floorSensor.Flying -= Fly;
        _controller.Moving -= Move;
    }

    private void Update()
    {
        if(_moveState != MoveState.Idle)
        {
            if (Time.time - _lastMoveTime > _stopTime)
            {
                _animator.SetBool(ParameterIsMoving, false);
                _moveState = MoveState.Idle;
            }
        }
    }

    private void Land()
    {
        _animator.SetBool(ParameterIsFlying, false);
    }

    private void Fly()
    {
        _animator.SetBool(ParameterIsFlying, true);
    }

    private void Move(float horizontal)
    {
        if(horizontal > 0f && _directionState != DirectionState.Right)
        {
            _directionState = DirectionState.Right;
            Rotate();
        }
        else if (horizontal < 0f && _directionState != DirectionState.Left)
        {
            _directionState = DirectionState.Left;
            Rotate();
        }

        if(_moveState != MoveState.Move)
        {
            _moveState = MoveState.Move;
            _animator.SetBool(ParameterIsMoving, true);
        }

        _lastMoveTime = Time.time;
    }

    private void Rotate()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}