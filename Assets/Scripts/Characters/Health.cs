using System;
using UnityEngine;

public class Health : BarViewable
{
    [SerializeField] private int _armor = 10;

    public event Action Died;
    public event Action Hurted;
    public override event Action ValueChanged;

    private void Awake()
    {
        ValueIn = MaximumValueIn;
    }

    public void TakeDamage(int damage)
    {
        GiveHealth(damage, _armor);
    }

    public int GiveHealth(int damage, int armor = 0)
    {
        int healthDelta = Math.Clamp(damage - armor, MinimumValueIn, MaximumValueIn);
        
        if(healthDelta > ValueIn)
            healthDelta = ValueIn;

        ValueIn -= healthDelta;
        ValueChanged?.Invoke();

        if (ValueIn == MinimumValueIn)
            Died?.Invoke();
        else
            Hurted?.Invoke();

        return healthDelta;
    }

    public void TakeHealing(int heal)
    {
        ValueIn = Math.Clamp(ValueIn + heal, MinimumValueIn, MaximumValueIn);
        ValueChanged?.Invoke();
    }
}
