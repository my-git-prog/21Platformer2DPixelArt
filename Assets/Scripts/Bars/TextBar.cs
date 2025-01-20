using TMPro;
using UnityEngine;

public class TextBar <T> : Bar <T> where T : IViewableInBar
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
        _textMaximumValue.text = ViewableInBar.MaximumValue.ToString();
    }

    protected override void SetValue()
    {
        _textValue.text = ViewableInBar.Value.ToString();
    }
}
