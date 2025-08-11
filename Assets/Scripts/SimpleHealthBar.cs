using R3;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _bar;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _health.PublicCurrentHealth.CombineLatest(_health.PublicMaxHealth, (current, max) => (current, max)).Subscribe(_ => ChangeBar()).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Dispose();
    }

    private void ChangeBar() =>
        _bar.fillAmount = _health.PublicCurrentHealth.CurrentValue / _health.PublicMaxHealth.CurrentValue;
}
