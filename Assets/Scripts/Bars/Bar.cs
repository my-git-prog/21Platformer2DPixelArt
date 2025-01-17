using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected BarViewable BarViewable;

    protected virtual void Start()
    {
        SetValue();
    }

    private void OnEnable()
    {
        BarViewable.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        BarViewable.ValueChanged -= SetValue;
    }

    protected abstract void SetValue();
}
