using System;
using UnityEngine;

public abstract class BarViewable : MonoBehaviour
{
    protected const int MinimumValueIn = 0;

    [SerializeField] protected int MaximumValueIn = 100;
    [SerializeField] protected int ValueIn = 100;

    public abstract event Action ValueChanged;

    public int MaximumValue => MaximumValueIn;
    public int Value => ValueIn;
}
