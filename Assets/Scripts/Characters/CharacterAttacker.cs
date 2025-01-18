using System;
using UnityEngine;

public class CharacterAttacker : MonoBehaviour
{
    [SerializeField] private CharacterFlipper _flipper;
    [SerializeField] private float _attackAreaAdvance = 1f;
    [SerializeField] private float _attackTime = 0.5f;
    [SerializeField] private float _kickAttackProbability = 0.3f;
    [SerializeField] private int _kickAttackDamage = 25;
    [SerializeField] private int _punchAttackDamage = 15;

    private float _lastAttackTime = 0f;

    public event Action Kicked;
    public event Action Punched;

    public void Attack<T>() where T : Character
    {
        if (Time.time - _lastAttackTime < _attackTime)
            return;

        _lastAttackTime = Time.time;

        int damage;

        if (UnityEngine.Random.value < _kickAttackProbability)
        {
            damage = _kickAttackDamage;
            Kicked?.Invoke();
        }
        else
        {
            damage = _punchAttackDamage;
            Punched?.Invoke();
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

        if (_flipper.Direction == CharacterDirection.Right)
            attackAreaCenter = new Vector2(transform.position.x + _attackAreaAdvance, transform.position.y);
        else
            attackAreaCenter = new Vector2(transform.position.x - _attackAreaAdvance, transform.position.y);

        return Physics2D.BoxCastAll(attackAreaCenter, Vector2.one, 0f, Vector2.one);
    }
}
