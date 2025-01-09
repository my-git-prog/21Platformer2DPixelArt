using System;
using UnityEngine;

public class Item: MonoBehaviour
{
    [SerializeField] protected int _parameter = 0;
    
    public event Action<Item> Taken;

    public int Parameter => _parameter;

    public void Take()
    {
        Taken?.Invoke(this);
    }
}
