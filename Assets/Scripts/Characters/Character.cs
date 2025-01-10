using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterMover Mover;
    [SerializeField] protected CharacterJumper Jumper;
    [SerializeField] protected CharacterFlipper Flipper;
    [SerializeField] protected CharacterView View;
    [SerializeField] protected int MaxHealth = 100;
    [SerializeField] protected int Armor = 10;
    [SerializeField] protected float AttackAreaAdvance = 0.5f;
    [SerializeField] protected float AttackAreaSize = 1f;
    [SerializeField] protected float AttackTime = 0.5f;
    [SerializeField] protected float KickAttackProbability = 0.3f;
    [SerializeField] protected int KickAttackDamage = 25;
    [SerializeField] protected int PunchAttackDamage = 15;
    [SerializeField] protected float DieTime = 1f;

    protected float LastAttackTime = 0f;
    protected int Health = 100;


    private void Awake()
    {
        Health = MaxHealth;
    }
    protected void Move()
    {
        float horizontal = GetHorizontalMovement();

        Mover.Move(horizontal);
        Flipper.Flip(horizontal);
        View.Move(horizontal);
    }

    protected abstract float GetHorizontalMovement();

    protected void Attack<T>() where T : Character
    {
        if (Time.time - LastAttackTime < AttackTime)
            return;

        LastAttackTime = Time.time;

        int damage;

        if (Random.value < KickAttackProbability)
        {
            View.KickAttack();
            damage = KickAttackDamage;
        }
        else
        {
            View.PunchAttack();
            damage = PunchAttackDamage;
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

        if (Flipper.Direction == CharacterDirection.Right)
            attackAreaCenter = new Vector2(transform.position.x + AttackAreaAdvance, transform.position.y);
        else
            attackAreaCenter = new Vector2(transform.position.x - AttackAreaAdvance, transform.position.y);

        return Physics2D.BoxCastAll(attackAreaCenter, Vector2.one, 0f, Vector2.one);
    }

    public void TakeDamage(int damage)
    {
        LastAttackTime = Time.time;
        Health -= (damage - Armor);

        if (Health < 0)
            Die();
        else
            View.Hurt();
    }

    private void Die()
    {
        View.Die();
        Invoke(nameof(DestroyCharacter), DieTime);
    }

    private void DestroyCharacter()
    {
        gameObject.SetActive(false);
    }
}
