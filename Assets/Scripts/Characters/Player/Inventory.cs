using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _money = 0;

    public event Action<int> MedicineTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _money += coin.Value;
            coin.Take();

        }
        else if (collision.TryGetComponent(out Medicine medicine))
        {
            MedicineTaken?.Invoke(medicine.Value);
            medicine.Take();
        }
    }
}