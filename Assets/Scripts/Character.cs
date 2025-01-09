using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterMover _mover;
    [SerializeField] protected CharacterView _view;
    [SerializeField] protected int _maxHealth = 100;
    [SerializeField] protected int _armor = 10;
    [SerializeField] protected float _attackAreaAdvance = 0.5f;
    [SerializeField] protected float _attackAreaSize = 1f;
    [SerializeField] protected float _attackTime = 0.5f;
    [SerializeField] protected float _kickAttackProbability = 0.3f;
    [SerializeField] protected int _kickAttackDamage = 25;
    [SerializeField] protected int _punchAttackDamage = 15;
    [SerializeField] protected float _dieTime = 1f;

    protected float _lastAttackTime = 0f;
    protected int _health = 100;


    private void Awake()
    {
        _health = _maxHealth;
    }
    protected void Move()
    {
        float horizontal = GetHorizontalMovement();

        _mover.Move(horizontal);
        _view.Move(horizontal);
    }

    protected abstract float GetHorizontalMovement();

    protected void Attack<T>() where T : Character
    {
        if (Time.time - _lastAttackTime < _attackTime)
            return;

        _lastAttackTime = Time.time;

        int damage;

        if (Random.value < _kickAttackProbability)
        {
            _view.KickAttack();
            damage = _kickAttackDamage;
        }
        else
        {
            _view.PunchAttack();
            damage = _punchAttackDamage;
        }


        foreach (var hit in GetAttackAreaHits())
        {
            if (hit.collider.TryGetComponent(out T enemy))
            {
                enemy.TakeDamage(damage);
                return;
            }
        }
    }

    private RaycastHit2D[] GetAttackAreaHits()
    {
        Vector2 attackAreaCenter;

        if (_view.Direction == DirectionState.Right)
            attackAreaCenter = new Vector2(transform.position.x + _attackAreaAdvance, transform.position.y);
        else
            attackAreaCenter = new Vector2(transform.position.x - _attackAreaAdvance, transform.position.y);

        return Physics2D.BoxCastAll(attackAreaCenter, Vector2.one, 0f, Vector2.one);
    }

    public void TakeDamage(int damage)
    {
        _lastAttackTime = Time.time;
        _health -= (damage - _armor);

        if (_health < 0)
            Die();

        _view.Hurt();
    }

    private void Die()
    {
        _view.Die();
        Invoke(nameof(DestroyCharacter), _dieTime);
    }

    private void DestroyCharacter()
    {
        gameObject.SetActive(false);
    }
}
