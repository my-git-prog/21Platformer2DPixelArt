using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string ParameterIsFlying = "IsFlying";
    private const string ParameterIsMoving = "IsMoving";
    private const string ParameterKickAttack = "KickAttack";
    private const string ParameterPunchAttack = "PunchAttack";
    private const string ParameterHurt = "Hurt";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move()
    {
        _animator.SetBool(ParameterIsMoving, true);
    }

    public void Stop()
    {
        _animator.SetBool(ParameterIsMoving, false);
    }

    public void Fly()
    {
        _animator.SetBool(ParameterIsFlying, true);
    }

    public void Land()
    {
        _animator.SetBool(ParameterIsFlying, false);
    }

    public void KickAttack()
    {
        _animator.SetTrigger(ParameterKickAttack);
    }

    public void PunchAttack()
    {
        _animator.SetTrigger(ParameterPunchAttack);
    }

    public void Hurt()
    {
        _animator.SetTrigger(ParameterHurt);
    }
}
