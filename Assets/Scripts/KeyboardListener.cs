using System;
using UnityEngine;

public class KeyboardListener : CommandManager
{
    const string Horizontal = "Horizontal";
    const string Jump = "Jump";

    public override event Action<float> Moving;
    public override event Action Jumping;

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float jump = Input.GetAxisRaw(Jump);

        if (horizontal != 0f)
        {
            Moving?.Invoke(horizontal);
        }

        if (jump > 0f)
            Jumping?.Invoke();
    }
}
