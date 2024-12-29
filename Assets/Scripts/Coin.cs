using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Destroying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Wallet wallet))
        {
            Destroying?.Invoke(this);
        }
    }
}