using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Taken;

    public void Take()
    {
        Taken?.Invoke(this);
    }
}