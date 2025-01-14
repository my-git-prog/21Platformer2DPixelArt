using System;
using UnityEngine;

public class Item: MonoBehaviour
{
    [SerializeField] private int Parameter = 0;
    [SerializeField] private int _minimumParameter = 5;
    [SerializeField] private int _maximumParameter = 20;

    public event Action<Item> Taken;
    
    public int Value => Parameter;

    private void Awake()
    {
        Parameter = UnityEngine.Random.Range(_minimumParameter, _maximumParameter);
    }

    public void Take()
    {
        Taken?.Invoke(this);
    }
}
