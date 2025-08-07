using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _bar;

    [SerializeField] private float _barChangingSpeed = 0.25f;
    [SerializeField] private float _barChangingDelay = 0.25f;


    private Coroutine _smoothChangeBarCoroutine;
    private WaitForSecondsRealtime _delay;

    private float _targetHealth;

    private void Awake()
    {
        _delay = new WaitForSecondsRealtime(_barChangingDelay);
    }

    private void OnEnable()
    {
        _health.Dead += SetBarToDefault;
        _health.MaxHealth.ValueChanged += StartSmoothChangingBar;
        _health.CurrentHealth.ValueChanged += StartSmoothChangingBar;
    }

    private void OnDisable()
    {
        _health.Dead -= SetBarToDefault;
        _health.MaxHealth.ValueChanged -= StartSmoothChangingBar;
        _health.CurrentHealth.ValueChanged -= StartSmoothChangingBar;
    }

    private void StartSmoothChangingBar(float oldValue, float newValue)
    {
        _targetHealth = newValue;

        if (_smoothChangeBarCoroutine != null)
        {
            StopCoroutine(_smoothChangeBarCoroutine);
            _smoothChangeBarCoroutine = null;
        }

        _smoothChangeBarCoroutine = StartCoroutine(SmoothChangeBar(oldValue, newValue));
    }

    private IEnumerator SmoothChangeBar(float oldValue, float newValue)
    {
        float targetFill = _targetHealth / _health.MaxHealth.Value;
        float currentFill = _bar.fillAmount;

        AdjustBar(currentFill, targetFill);

        yield return _delay;

        while (Mathf.Approximately(_bar.fillAmount, targetFill) == false)
        {
            targetFill = _targetHealth / _health.MaxHealth.Value;

            AdjustBar(currentFill, targetFill);

            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, targetFill, _barChangingSpeed * Time.unscaledDeltaTime);
            currentFill = _bar.fillAmount;

            yield return null;
        }

        _smoothChangeBarCoroutine = null;
    }

    private void AdjustBar(float currentFill, float targetFill)
    {
        if (currentFill < targetFill)
        {
            _bar.fillAmount = targetFill;
        }
    }

    private void SetBarToDefault() =>
    _bar.fillAmount = _health.MaxHealth.Value;
}
