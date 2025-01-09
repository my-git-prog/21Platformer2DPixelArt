using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private DirectionState _directionState = DirectionState.Right;
    [SerializeField] private float _stopTime = 0.2f;

    private float _lastMoveTime = 0f;
    private MoveState _moveState = MoveState.Idle;

    public DirectionState Direction => _directionState;

    private void OnEnable()
    {
        _floorSensor.Landed += _characterAnimator.Land;
        _floorSensor.Flied += _characterAnimator.Fly;
    }

    private void OnDisable()
    {
        _floorSensor.Landed -= _characterAnimator.Land;
        _floorSensor.Flied -= _characterAnimator.Fly;
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

    public void Move(float horizontal)
    {
        if (horizontal == 0f)
            return;

        _lastMoveTime = Time.time;

        if (horizontal > 0f && _directionState != DirectionState.Right)
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
    }

    private void Rotate()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void KickAttack()
    {
        _characterAnimator.KickAttack();
    }
    public void PunchAttack()
    {
        _characterAnimator.PunchAttack();
    }

    public void Hurt()
    {
        _characterAnimator.Hurt();
    }

    public void Die()
    {
        _characterAnimator.Die();
    }
}