using UnityEngine;
using UnityEngine.UI;

public class RealBar : Bar
{
    [SerializeField] private Slider _slider;

    protected override void SetValue()
    {
        _slider.value = ((float)BarViewable.Value / BarViewable.MaximumValue);
    }
}
