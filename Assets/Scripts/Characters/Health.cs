using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumValue = 100;
    [SerializeField] private int _minimumValue = 0;
    [SerializeField] private int _armor = 10;
    [SerializeField] private int _value = 100;

    public event Action Died;
    public event Action Hurted;

    private void Awake()
    {
        _value = _maximumValue;
    }

    public void TakeDamage(int damage)
    {
        _value -= Math.Clamp(damage - _armor, _minimumValue, _maximumValue);
        _value = Math.Clamp(_value, _minimumValue, _maximumValue);

        if (_value == 0)
            Died?.Invoke();
        else
            Hurted?.Invoke();
    }

    public void TakeHeal(int medicine)
    {
        _value = Math.Clamp(_value + medicine, _minimumValue, _maximumValue);
    }
}
