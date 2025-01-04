using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private DirectionState _directionState = DirectionState.Right;
    [SerializeField] private float _stopTime = 0.2f;

    private float _lastMoveTime = 0f;
    private MoveState _moveState = MoveState.Idle;


    private void OnEnable()
    {
        _floorSensor.Landed += Land;
        _floorSensor.Flied += Fly;
    }

    private void OnDisable()
    {
        _floorSensor.Landed -= Land;
        _floorSensor.Flied -= Fly;
    }

    private void Update()
    {
        if(_moveState != MoveState.Idle)
        {
            if (Time.time - _lastMoveTime > _stopTime)
            {
                _characterAnimator.Stop();
                _moveState = MoveState.Idle;
            }
        }
    }

    private void Land()
    {
        _characterAnimator.Land();
    }

    private void Fly()
    {
        _characterAnimator.Fly();
    }

    public void Move(float horizontal)
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
            _characterAnimator.Move();
        }

        _lastMoveTime = Time.time;
    }

    private void Rotate()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}