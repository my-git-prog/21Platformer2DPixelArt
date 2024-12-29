using System;
using UnityEngine;

public class PlayerController : Controller
{
    const string HorizontalAxis = "Horizontal";
    const string JumpAxis = "Jump";

    public override event Action<float> Moving;
    public override event Action Jumping;

    void Update()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        float jump = Input.GetAxisRaw(JumpAxis);

        if (horizontal != 0f)
        {
            Moving?.Invoke(horizontal);
        }

        if (jump > 0f)
            Jumping?.Invoke();
    }
}