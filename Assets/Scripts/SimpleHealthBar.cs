using TMPro;
using UnityEngine;

public class SimpleHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private TMP_Text _textMeshPro;

    private void Awake()
    {
        DrawHealth(0f, 0f);
    }

    private void OnEnable()
    {
        _health.MaxHealth.ValueChanged += DrawHealth;
        _health.CurrentHealth.ValueChanged += DrawHealth;
    }

    private void OnDisable()
    {
        _health.MaxHealth.ValueChanged -= DrawHealth;
        _health.CurrentHealth.ValueChanged -= DrawHealth;
    }


    private void DrawHealth(float oldValue, float newValue)
    {
        _textMeshPro.text = $"HP [{_health.CurrentHealth.Value}/{_health.MaxHealth.Value}]";
    }
}
