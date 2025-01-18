using System;
using UnityEngine;

public class Health : ParameterViewable
{
    [SerializeField] private int _armor = 10;

    public event Action Died;
    public event Action Hurted;
    public override event Action ValueChanged;

    private void Awake()
    {
        ValueIn = MaximumValueIn;
    }

    public int TakeDamage(int damage, bool useArmor = true)
    {
        int delta = Math.Clamp(damage - (useArmor?_armor:0), MinimumValueIn, MaximumValueIn);

        if (delta > ValueIn)
            delta = ValueIn;

        ValueIn -= delta;
        ValueChanged?.Invoke();

        if (ValueIn == MinimumValueIn)
            Died?.Invoke();
        else
            Hurted?.Invoke();

        return delta;
    }

    public void TakeHealing(int heal)
    {
        ValueIn = Math.Clamp(ValueIn + heal, MinimumValueIn, MaximumValueIn);
        ValueChanged?.Invoke();
    }
}
