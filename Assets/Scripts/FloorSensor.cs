using System;
using UnityEngine;

public class FloorSensor : MonoBehaviour
{
    public event Action Landing;
    public event Action Flying;

    public bool OnFloor { get; private set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Floor floor))
        {
            Flying?.Invoke();
            OnFloor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Floor floor))
        {
            Landing?.Invoke();
            OnFloor = true;
        }
    }
}