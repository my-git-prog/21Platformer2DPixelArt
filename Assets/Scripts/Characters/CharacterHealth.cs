using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int _maximumHealth = 100;
    [SerializeField] private int _armor = 10;
    [SerializeField] private int _health = 100;

    public event Action Died;
    public event Action Hurted;

    private void Awake()
    {
        _health = _maximumHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= (damage - _armor);

        if (_health < 0)
            Died?.Invoke();
        else
            Hurted?.Invoke();
    }

    public void Heal(int medicine)
    {
        int health = _health + medicine;

        if (health > _maximumHealth)
            _health = _maximumHealth;
        else
            _health = health;
    }
}
