using System;
using UnityEngine;

public class Item: MonoBehaviour
{
    [SerializeField] private int _value = 0;
    [SerializeField] private int _minimumValue = 5;
    [SerializeField] private int _maximumValue = 20;

    public event Action<Item> Taken;
    
    public int Value => _value;

    private void Awake()
    {
        _value = UnityEngine.Random.Range(_minimumValue, _maximumValue);
    }

    public void Take()
    {
        Taken?.Invoke(this);
    }
}
