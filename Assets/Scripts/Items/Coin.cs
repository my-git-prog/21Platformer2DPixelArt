using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int _minimumMoney = 1;
    [SerializeField] private int _maximumMoney = 10;

    private void Awake()
    {
        Parameter = Random.Range(_minimumMoney, _maximumMoney);
    }
}