using System;
public class ReactiveFloat
{
    public event Action<float, float> ValueChanged;

    private float _value;

    public ReactiveFloat(float value)
    {
        _value = value;
    }

    public float Value
    {
        get => _value;
        set
        {
          float oldValue = _value;

            _value = value;

            if (_value != oldValue)
                ValueChanged?.Invoke(oldValue, _value);
        }
    }
}