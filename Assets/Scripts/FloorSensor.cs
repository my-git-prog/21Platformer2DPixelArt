using System;
using UnityEngine;

public class FloorSensor : MonoBehaviour
{
    private LandingState _landingState = LandingState.InAir;

    public event Action Landing;
    public event Action Flying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckLanding(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckFlying(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckLanding(collision);
    }

    private void CheckLanding(Collider2D collision)
    {
        if (_landingState == LandingState.InAir)
        {
            if (collision.TryGetComponent(out Floor component))
            {
                Landing?.Invoke();
                _landingState = LandingState.OnFloor;
            }
        }
    }

    private void CheckFlying(Collider2D collision)
    {
        if (_landingState == LandingState.OnFloor)
        {
            if (collision.TryGetComponent(out Floor component))
            {
                Flying?.Invoke();
                _landingState = LandingState.InAir;
            }
        }
    }
}