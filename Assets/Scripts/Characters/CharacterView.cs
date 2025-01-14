using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private FloorSensor _floorSensor;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private Character _character;
    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private CharacterAttacker _characterAttacker;
    [SerializeField] private float _stopTime = 0.2f;

    private float _lastMoveTime = 0f;
    private CharacterStates _moveState = CharacterStates.Idle;

    private void OnEnable()
    {
        _floorSensor.Landed += _characterAnimator.Land;
        _floorSensor.Flied += _characterAnimator.Fly;
        _character.Moved += Move;
        _characterHealth.Died += Die;
        _characterHealth.Hurted += Hurt;
        _characterAttacker.Kicked += KickAttack;
        _characterAttacker.Punched += PunchAttack;
    }

    private void OnDisable()
    {
        _floorSensor.Landed -= _characterAnimator.Land;
        _floorSensor.Flied -= _characterAnimator.Fly;
        _character.Moved -= Move;
        _characterHealth.Died -= Die;
        _characterHealth.Hurted -= Hurt;
        _characterAttacker.Kicked -= KickAttack;
        _characterAttacker.Punched -= PunchAttack;
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

    private void Move(float horizontal)
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

    private void KickAttack()
    {
        _characterAnimator.KickAttack();
    }
    private void PunchAttack()
    {
        _characterAnimator.PunchAttack();
    }

    private void Hurt()
    {
        _characterAnimator.Hurt();
    }

    private void Die()
    {
        _characterAnimator.Die();
    }
}