using System;

public interface IViewableInBar
{
    public event Action ValueChanged;
    public int Value { get; }
    public int MaximumValue { get; }
}
