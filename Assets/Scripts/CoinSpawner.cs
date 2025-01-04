using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawnPoint[] _coinSpawnPoints;
    [SerializeField] private float _spawnDeltaTime = 1f;
    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<Coin> _coinPool;

    private void Awake()
    {
        _coinPool = new ObjectPool<Coin>(
            createFunc: () => CreateCoin(),
            actionOnGet: (coin) => ActiovateCoin(coin),
            actionOnRelease: (coin) => DeactivateCoin(coin),
            actionOnDestroy: (coin) => DestroyCoin(coin),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private Coin CreateCoin()
    {
        Coin newCoin = Instantiate(_coinPrefab);
        newCoin.Taken += ReleaseCoin;

        return newCoin;
    }

    private void ReleaseCoin(Coin coin)
    {
        _coinPool.Release(coin);
    }

    private void ActiovateCoin(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void DeactivateCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void DestroyCoin(Coin coin)
    {
        coin.Taken -= ReleaseCoin;
        Destroy(coin.gameObject);
    }

    private void TrySpawnCoin()
    {
        CoinSpawnPoint randomSpawnPoint = _coinSpawnPoints[Random.Range(0, _coinSpawnPoints.Length)];

        if (randomSpawnPoint.IsEmpty)
        {
            randomSpawnPoint.AddCoin(_coinPool.Get());
        }
    }

    private IEnumerator SpawnCoins()
    {
        var wait = new WaitForSeconds(_spawnDeltaTime);

        while(_isSpawning)
        {
            TrySpawnCoin();
            yield return wait;
        }
    }
}