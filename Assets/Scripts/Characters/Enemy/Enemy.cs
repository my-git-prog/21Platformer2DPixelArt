using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyPatrolling _patrolling;
    [SerializeField] private EnemyAttackArea _attackArea;

    protected override void OnEnable()
    {
        base.OnEnable();
        _patrolling.BarrierReached += Jumper.Jump;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _patrolling.BarrierReached -= Jumper.Jump;
    }

    private void Update()
    {
        if (_attackArea.IsPlayerReachable)
            Attacker.Attack<Player>();
        else
            Move();
    }

    protected override float GetHorizontalMovement()
    {
        return _patrolling.GetHorizontalMovement();
    }
}
