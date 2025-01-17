using System;
using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterMover Mover;
    [SerializeField] protected CharacterJumper Jumper;
    [SerializeField] protected CharacterFlipper Flipper;
    [SerializeField] protected CharacterAttacker Attacker;
    [SerializeField] protected Health Health;
    [SerializeField] protected float DieTime = 1f;

    public event Action<float> Moved;

    protected virtual void OnEnable()
    {
        Health.Died += Die;
    }

    protected virtual void OnDisable()
    {
        Health.Died -= Die;
    }

    protected void Move()
    {
        float horizontal = GetHorizontalMovement();

        Mover.Move(horizontal);
        Flipper.Flip(horizontal);
        Moved?.Invoke(horizontal);
    }

    protected abstract float GetHorizontalMovement();

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }

    public int GiveHealth(int health)
    {
        return Health.GiveHealth(health);
    }
}
