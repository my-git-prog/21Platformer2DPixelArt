using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealBar : Bar
{
    [SerializeField] private Slider _slider;

    protected override void SetValue()
    {
        base.SetValue();

        _slider.value = ((float)Value/MaximumValue);
    }
}
