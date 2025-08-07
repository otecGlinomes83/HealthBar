using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.CurrentHealth.ValueChanged += ChangeBar;
    }

    private void OnDisable()
    {
        _health.CurrentHealth.ValueChanged -= ChangeBar;
    }

    private void ChangeBar(float oldValue, float newValue) =>
        _bar.fillAmount = newValue / _health.MaxHealth.Value;
}
