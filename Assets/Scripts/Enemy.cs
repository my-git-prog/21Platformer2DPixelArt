using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _wayPointDistance = 1f;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private EnemyAttackArea _attackArea;
    [SerializeField] private FloorSensor _barrierSensor;

    private int _currentWayPointNumber = 0;
    private Player _target;
    private bool _playerIsFinded = false;

    private void OnEnable()
    {
        _vision.PlayerFinded += SetMovementTarget;
        _barrierSensor.Landed += _mover.Jump;
    }

    private void OnDisable()
    {
        _vision.PlayerFinded -= SetMovementTarget;
        _barrierSensor.Landed -= _mover.Jump;
    }

    private void Update()
    {
        if (_attackArea.IsPlayerReachable)
            Attack<Player>();
        else
            Move();
    }

    private void SetMovementTarget(Player player)
    {
        _target = player;
        _playerIsFinded = true;
    }

    protected override float GetHorizontalMovement()
    {
        Vector3 way;
        
        if (_playerIsFinded)
        {
            way = _target.transform.position - transform.position;
        }
        else
        {
            way = _wayPoints[_currentWayPointNumber].transform.position - transform.position;

            if (way.magnitude < _wayPointDistance)
                _currentWayPointNumber = ++_currentWayPointNumber % _wayPoints.Length;
        }

        return way.normalized.x;
    }
}
