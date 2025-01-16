using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : Bar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed = 0.01f;
    [SerializeField] private float _smoothDeltaTime = 0.1f;

    private float _targetSliderValue = 1.0f;
    private Coroutine _coroutine;

    protected override void SetValue()
    {
        base.SetValue();

        if(_coroutine != null )
            StopCoroutine(_coroutine);

        _targetSliderValue = ((float)Value / MaximumValue);

        _coroutine = StartCoroutine(SmoothSlider());
    }

    private IEnumerator SmoothSlider()
    {
        var wait = new WaitForSeconds(_smoothDeltaTime);

        while(_slider.value != _targetSliderValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetSliderValue, _smoothSpeed);

            yield return wait;
        }
    }

}
