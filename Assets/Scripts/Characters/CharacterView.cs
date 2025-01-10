using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private float _stopTime = 0.2f;

    private float _lastMoveTime = 0f;
    private CharacterStates _moveState = CharacterStates.Idle;

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
        if(_moveState != CharacterStates.Idle)
        {
            if (Time.time - _lastMoveTime > _stopTime)
            {
                _characterAnimator.Stop();
                _moveState = CharacterStates.Idle;
            }
        }
    }

    public void Move(float horizontal)
    {
        if (horizontal == 0f)
            return;

        _lastMoveTime = Time.time;

        if(_moveState != CharacterStates.Move)
        {
            _moveState = CharacterStates.Move;
            _characterAnimator.Move();
        }
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