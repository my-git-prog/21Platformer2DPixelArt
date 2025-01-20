using System;
using System.Collections;
using UnityEngine;

public class MagicVampire : MonoBehaviour, IViewableInBar
{
    private const int MinimumValue = 0;

    [SerializeField] private int _value = 0;
    [SerializeField] private int _maximumValue = 100;
    [SerializeField] private float _restoreTime = 4f;
    [SerializeField] private float _consumeTime = 6f;
    [SerializeField] private float _timeStep = 0.3f;
    [SerializeField] private int _healthOneStep = 1;
    [SerializeField] private MagicArea _area;
    [SerializeField] private Health _health;

    public event Action ValueChanged;

    public int MaximumValue => _maximumValue;
    public int Value => _value;


    private void Awake()
    {
        _value = MinimumValue;
        ValueChanged?.Invoke();
    }

    private void Start()
    {
        _area.gameObject.SetActive(false);
        StartCoroutine(RestoreMana());
    }

    public void StartWorking()
    {
        if (_value < _maximumValue)
            return;

        _area.gameObject.SetActive(true);
        StartCoroutine(TakeHealthFromEnemies());
    }

    private void StopWorking()
    {
        _area.gameObject.SetActive(false);
        StartCoroutine(RestoreMana());
    }

    private IEnumerator RestoreMana()
    {
        float elapsedTime = 0f;
        var wait = new WaitForSeconds(_timeStep);

        while (elapsedTime < _restoreTime && _value < _maximumValue)
        {
            elapsedTime += _timeStep;
            _value = (int)Mathf.Lerp(MinimumValue, _maximumValue, elapsedTime / _restoreTime);
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
            _value = (int)Mathf.Lerp(_maximumValue, MinimumValue, elapsedTime / _consumeTime);
            ValueChanged?.Invoke();

            if(_area.TryGetEnemy(out Enemy enemy))
            {
                _health.TakeHealing(enemy.TakeDamage(_healthOneStep, false));
            }

            if (elapsedTime < _consumeTime)
            {
                yield return wait;
            }
            else
            {
                StopWorking();
            }
        }
    }
}
