using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Take();
            _money++;
        }
    }
}