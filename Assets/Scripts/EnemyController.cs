using System;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _wayPointDistance = 1f;

    private int _currentWayPointNumber = 0;

    public override event Action<float> Moving;
    public override event Action Jumping;

    void Update()
    {
        Vector3 way = _wayPoints[_currentWayPointNumber].transform.position - transform.position;

        if (way.magnitude < _wayPointDistance)
        {
            _currentWayPointNumber = ++_currentWayPointNumber % _wayPoints.Length;
            
            return;
        }

        Moving?.Invoke(way.normalized.x);
    }
}