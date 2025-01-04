using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string ParameterIsFlying = "IsFlying";
    private const string ParameterIsMoving = "IsMoving";

    [SerializeField] private Animator _animator;

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
}
