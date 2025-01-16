using TMPro;
using UnityEngine;

public class TextBar : Bar
{
    [SerializeField] private TextMeshProUGUI _textMaximumValue;
    [SerializeField] private TextMeshProUGUI _textValue;

    protected override void SetMaximumValue()
    {
        base.SetMaximumValue();

        _textMaximumValue.text = MaximumValue.ToString();
    }

    protected override void SetValue()
    {
        base.SetValue();

        _textValue.text = Value.ToString();
    }
}
