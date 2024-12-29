using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public virtual event Action<float> Moving;
    public virtual event Action Jumping;
}
