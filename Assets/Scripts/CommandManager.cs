using System;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public virtual event Action<float> Moving;
    public virtual event Action Jumping;
}
