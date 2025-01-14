using System;
using UnityEngine;

public class FloorSensor : MonoBehaviour
{
    private int _landingCount = 0;

    public event Action Landed;
    public event Action Flied;

    public bool IsFloor { get; private set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Floor floor))
        {
            if(--_landingCount == 0)
            {
                Flied?.Invoke();
                IsFloor = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Floor floor))
        {
            if(_landingCount++ == 0)
            {
                Landed?.Invoke();
                IsFloor = true;
            }
        }
    }
}