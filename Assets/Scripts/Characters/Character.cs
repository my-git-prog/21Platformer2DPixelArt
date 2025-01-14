using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterMover Mover;
    [SerializeField] protected CharacterJumper Jumper;
    [SerializeField] protected CharacterFlipper Flipper;
    [SerializeField] protected CharacterAttacker Attacker;
    [SerializeField] protected CharacterHealth Health;
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
        Invoke(nameof(DestroyCharacter), DieTime);
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }

    private void DestroyCharacter()
    {
        gameObject.SetActive(false);
    }
}
