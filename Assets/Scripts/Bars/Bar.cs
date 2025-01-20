using UnityEngine;

public abstract class Bar<T> : MonoBehaviour where T : IViewableInBar
{
    [SerializeField] public T ViewableInBar;

    protected virtual void Start()
    {
        SetValue();
    }

    private void OnEnable()
    {
        ViewableInBar.ValueChanged += SetValue;
    }

    private void OnDisable()
    {
        ViewableInBar.ValueChanged -= SetValue;
    }

    protected abstract void SetValue();
}
