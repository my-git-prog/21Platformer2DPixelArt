using System;
using UnityEngine;

public class Health : MonoBehaviour, IViewableInBar
{
    private const int MinimumValue = 0;

    [SerializeField] private int _armor = 10;
    [SerializeField] private int _maximumValue = 100;
    [SerializeField] private int _value = 100;

    public event Action Died;
    public event Action Hurted;
    public event Action ValueChanged;

    public int MaximumValue => _maximumValue;
    public int Value => _value;

    private void Awake()
    {
        _value = _maximumValue;
    }

    public int TakeDamage(int damage, bool useArmor = true)
    {
        int delta = Math.Clamp(damage - (useArmor?_armor:0), MinimumValue, _maximumValue);

        if (delta > _value)
            delta = _value;

        _value -= delta;
        ValueChanged?.Invoke();

        if (_value == MinimumValue)
            Died?.Invoke();
        else
            Hurted?.Invoke();

        return delta;
    }

    public void TakeHealing(int heal)
    {
        _value = Math.Clamp(_value + heal, MinimumValue, _maximumValue);
        ValueChanged?.Invoke();
    }
}
