using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _money = 0;

    public event Action<int> MedicineTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (item is Coin) 
                _money += item.Value;
            else if(item is Medicine)
                MedicineTaken?.Invoke(item.Value);

            item.Take();
        }
    }
}