using System;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _wayPointDistance = 1f;
    [SerializeField] private EnemyVision _vision;
    [SerializeField] private FloorSensor _barrierSensor;

    private int _currentWayPointNumber = 0;
    private Player _target;
    private bool _playerIsFinded = false;

    public event Action BarrierReached;

    private void OnEnable()
    {
        _vision.PlayerFinded += SetMovementTarget;
        _barrierSensor.Landed += BarrierReach;
    }

    private void OnDisable()
    {
        _vision.PlayerFinded -= SetMovementTarget;
        _barrierSensor.Landed -= BarrierReach;
    }

    private void BarrierReach()
    {
        BarrierReached?.Invoke();
    }

    private void SetMovementTarget(Player player)
    {
        _target = player;
        _playerIsFinded = true;
    }

    public float GetHorizontalMovement()
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
