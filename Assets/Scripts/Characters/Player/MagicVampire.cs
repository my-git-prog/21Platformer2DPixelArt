using System;
using System.Collections;
using UnityEngine;

public class MagicVampire : BarViewable
{
    [SerializeField] private float _restoreTime = 4f;
    [SerializeField] private float _consumeTime = 6f;
    [SerializeField] private float _timeStep = 0.3f;
    [SerializeField] private int _healthOneStep = 1;
    [SerializeField] private MagicArea _area;
    [SerializeField] private Health _health;

    public override event Action ValueChanged;

    private void Awake()
    {
        ValueIn = MinimumValueIn;
        ValueChanged?.Invoke();
    }

    private void Start()
    {
        _area.gameObject.SetActive(false);
        StartCoroutine(RestoreMana());
    }

    public void StartMagic()
    {
        if (ValueIn < MaximumValueIn)
            return;

        _area.gameObject.SetActive(true);
        StartCoroutine(TakeHealthFromEnemies());
    }

    private void StopMagic()
    {
        _area.gameObject.SetActive(false);
        StartCoroutine(RestoreMana());
    }

    private IEnumerator RestoreMana()
    {
        float elapsedTime = 0f;
        var wait = new WaitForSeconds(_timeStep);

        while (elapsedTime < _restoreTime && ValueIn < MaximumValueIn)
        {
            elapsedTime += _timeStep;
            ValueIn = (int)Mathf.Lerp(MinimumValueIn, MaximumValueIn, elapsedTime / _restoreTime);
            ValueChanged?.Invoke();

            yield return wait;
        }
    }

    private IEnumerator TakeHealthFromEnemies()
    {
        float elapsedTime = 0f;
        var wait = new WaitForSeconds(_timeStep);

        while (elapsedTime < _consumeTime)
        {
            elapsedTime += _timeStep;
            ValueIn = (int)Mathf.Lerp(MaximumValueIn, MinimumValueIn, elapsedTime / _consumeTime);
            ValueChanged?.Invoke();

            if(_area.TryGetEnemy(out Enemy enemy))
            {
                _health.TakeHealing(enemy.GiveHealth(_healthOneStep));
            }

            if (elapsedTime < _consumeTime)
            {
                yield return wait;
            }
            else
            {
                StopMagic();
            }
        }
    }
}
