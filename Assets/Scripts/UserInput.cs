using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpAxis = "Jump";
    private const string AttackAxis = "Fire1";

    public event Action JumpButtonClicked;
    public event Action AttackButtonClicked;

    public float Horizontal => Input.GetAxis(HorizontalAxis);

    private void Update()
    {
        float jump = Input.GetAxisRaw(JumpAxis);

        if (jump > 0f)
            JumpButtonClicked?.Invoke();

        float attack = Input.GetAxisRaw(AttackAxis);

        if (attack > 0f)
            AttackButtonClicked?.Invoke();
    }
}
