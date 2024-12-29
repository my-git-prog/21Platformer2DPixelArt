using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set;}

    private void Awake()
    {
        IsEmpty = true;
    }

    public void AddCoin(Coin coin)
    {
        IsEmpty = false;
        coin.Destroying += Empty;
        coin.transform.position = transform.position;
    }

    private void Empty(Coin coin)
    {
        IsEmpty = true;
        coin.Destroying -= Empty;
    }
}