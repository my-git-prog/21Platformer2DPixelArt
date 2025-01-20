using UnityEngine;
using UnityEngine.UI;

public class RealBar<T> : Bar<T> where T : IViewableInBar
{
    [SerializeField] private Slider _slider;

    protected override void SetValue()
    {
        _slider.value = ((float)ViewableInBar.Value / ViewableInBar.MaximumValue);
    }
}
