using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Destroying;

    public void Take()
    {
        Destroying?.Invoke(this);
    }
}