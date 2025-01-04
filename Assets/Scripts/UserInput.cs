using System;
using UnityEngine;

public class UserInput : Input
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    public override event Action<float> Moving;
    public override event Action Jumping;

    private void Update()
    {
        float horizontal = UnityEngine.Input.GetAxis(Horizontal);
        float jump = UnityEngine.Input.GetAxisRaw(Jump);

        if (horizontal != 0f)
            Moving?.Invoke(horizontal);

        if (jump > 0f)
            Jumping?.Invoke();
    }
}
