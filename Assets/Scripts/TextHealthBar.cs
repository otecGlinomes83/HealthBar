using R3;
using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _textMeshPro;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        DrawHealth();

        _health.PublicCurrentHealth.CombineLatest(_health.PublicMaxHealth, (current, max) => (current, max)).Subscribe(_ => DrawHealth()).AddTo(_disposable);
    }

    private void OnDisable() =>
        _disposable?.Dispose();


    private void DrawHealth() =>
        _textMeshPro.text = $"HP [{_health.PublicCurrentHealth.CurrentValue}/{_health.PublicMaxHealth.CurrentValue}]";
}
