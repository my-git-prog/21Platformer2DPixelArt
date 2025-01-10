using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyPatrolling _patrolling;
    [SerializeField] private EnemyAttackArea _attackArea;
    [SerializeField] private FloorSensor _barrierSensor;

    private void OnEnable()
    {
        _barrierSensor.Landed += Jumper.Jump;
    }

    private void OnDisable()
    {
        _barrierSensor.Landed -= Jumper.Jump;
    }

    private void Update()
    {
        if (_attackArea.IsPlayerReachable)
            Attack<Player>();
        else
            Move();
    }

    protected override float GetHorizontalMovement()
    {
        return _patrolling.GetHorizontalMovement();
    }
}
