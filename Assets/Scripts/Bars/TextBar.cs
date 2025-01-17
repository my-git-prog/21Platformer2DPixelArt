using TMPro;
using UnityEngine;

public class TextBar : Bar
{
    [SerializeField] private TextMeshProUGUI _textMaximumValue;
    [SerializeField] private TextMeshProUGUI _textValue;

    protected override void Start()
    {
        base.Start();
        SetMaximumValue();
    }

    private void SetMaximumValue()
    {
        _textMaximumValue.text = BarViewable.MaximumValue.ToString();
    }

    protected override void SetValue()
    {
        _textValue.text = BarViewable.Value.ToString();
    }
}
