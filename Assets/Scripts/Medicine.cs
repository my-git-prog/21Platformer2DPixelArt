using UnityEngine;

public class Medicine : Item
{
    [SerializeField] private int _minimumHealth = 10;
    [SerializeField] private int _maximumHealth = 30;

    private void Awake()
    {
        _parameter = Random.Range(_minimumHealth, _maximumHealth);
    }
}
