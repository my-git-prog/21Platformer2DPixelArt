using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected int MaximumValue;
    protected int Value;

    private void Start()
    {
        SetMaximumValue();
        SetValue();
    }

    private void OnEnable()
    {
        _health.ValueChanged += SetValue;
    }
    private void OnDisable()
    {
        _health.ValueChanged -= SetValue;
    }

    protected virtual void SetMaximumValue()
    {
        MaximumValue = _health.MaximumValue;
    }

    protected virtual void SetValue()
    {
        Value = _health.Value;
    }
}
