using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    public virtual event Action<float> Moving;
    public virtual event Action Jumping;
}
