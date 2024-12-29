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
            createFunc: () => CreateFunc(),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => ActionOnDestroy(obj),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private Coin CreateFunc()
    {
        Coin newCoin = Instantiate(_coinPrefab);
        newCoin.Destroying += DestroyingCoin;

        return newCoin;
    }

    private void DestroyingCoin(Coin coin)
    {
        _coinPool.Release(coin);
    }

    private void ActionOnGet(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Coin coin)
    {
        coin.Destroying -= DestroyingCoin;
        Destroy(coin);
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