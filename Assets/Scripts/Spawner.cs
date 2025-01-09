using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner <T> : MonoBehaviour where T : Item
{
    [SerializeField] private ItemSpawnPoint[] _itemSpawnPoints;
    [SerializeField] private float _spawnDeltaTime = 1f;
    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private T _prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 50;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => CreateItem(),
            actionOnGet: (item) => ActivateItem(item),
            actionOnRelease: (item) => DeactivateItem(item),
            actionOnDestroy: (item) => DestroyItem(item),
            collectionCheck: true,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private T CreateItem()
    {
        T newItem = Instantiate(_prefab);
        newItem.Taken += ReleaseItem;

        return newItem;
    }

    private void ReleaseItem(Item item)
    {
        _pool.Release(item as T);
    }

    private void ActivateItem(T item)
    {
        item.gameObject.SetActive(true);
    }

    private void DeactivateItem(T item)
    {
        item.gameObject.SetActive(false);
    }

    private void DestroyItem(T item)
    {
        item.Taken -= ReleaseItem;
        Destroy(item.gameObject);
    }

    private void TrySpawnCoin()
    {
        ItemSpawnPoint randomSpawnPoint = _itemSpawnPoints[Random.Range(0, _itemSpawnPoints.Length)];

        if (randomSpawnPoint.IsEmpty)
        {
            randomSpawnPoint.AddItem(_pool.Get());
        }
    }

    private IEnumerator SpawnCoins()
    {
        var wait = new WaitForSeconds(_spawnDeltaTime);

        while (_isSpawning)
        {
            TrySpawnCoin();
            yield return wait;
        }
    }
}