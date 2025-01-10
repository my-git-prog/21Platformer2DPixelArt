using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CharacterFlipper _playerFlipper;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _minimumPositionX = 0f;
    [SerializeField] private float _maximumPositionX = 10f;
    [SerializeField] private float _advance = 10f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float newPositionX = Mathf.MoveTowards(transform.position.x, GetTargetPositionX(), Time.deltaTime * _speed);

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    private float GetTargetPositionX()
    {
        float targetPositionX; 

        if (_playerFlipper.Direction == CharacterDirection.Right)
            targetPositionX = _playerFlipper.transform.position.x + _advance;
        else
            targetPositionX = _playerFlipper.transform.position.x - _advance;

        if (targetPositionX > _maximumPositionX)
            return _maximumPositionX;
        else if (targetPositionX < _minimumPositionX)
            return _minimumPositionX;

        return targetPositionX;
    }
}
