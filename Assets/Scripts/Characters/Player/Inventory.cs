using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _money = 0;
    [SerializeField] private SpawnerCoins _spawnerCoins;
    [SerializeField] private SpawnerMedicines _spawnerMedicines;

    public event Action<int> MedicineTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _money += coin.Value;
            _spawnerCoins.ReleaseItem(coin);

        }
        else if (collision.TryGetComponent(out Medicine medicine))
        {
            MedicineTaken?.Invoke(medicine.Value);
            _spawnerMedicines.ReleaseItem(medicine);
        }
    }
}