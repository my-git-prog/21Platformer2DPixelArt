using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpAxis = "Jump";
    private const string AttackAxis = "Fire1";
    private const string Attack2Axis = "Fire2";

    public event Action JumpButtonClicked;
    public event Action AttackButtonClicked;
    public event Action Attack2ButtonClicked;

    public float Horizontal => Input.GetAxis(HorizontalAxis);

    private void Update()
    {
        float jump = Input.GetAxisRaw(JumpAxis);

        if (jump > 0f)
            JumpButtonClicked?.Invoke();

        float attack = Input.GetAxisRaw(AttackAxis);

        if (attack > 0f)
            AttackButtonClicked?.Invoke();

        float attack2 = Input.GetAxisRaw(Attack2Axis);

        if (attack2 > 0f)
            Attack2ButtonClicked?.Invoke();
    }
}
